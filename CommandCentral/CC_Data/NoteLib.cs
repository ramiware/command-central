using CommandCentral.CC_Common;
using CommandCentral.CC_UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommandCentral.CC_Data
{
    class NoteLib
    {
        private string NOTELIB_FILEPATH = "";

        public NoteLib()
        {
            // Create Path if it does not exist - C:\Users\ramis\AppData\Local\Ramiware\
            NOTELIB_FILEPATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create), About.APP_PARENT_NAME + @"\" + About.APP_NAME_LONG);
            NOTELIB_FILEPATH += @"\";
        }

        /// <summary>
        /// Returns a list of all note files found in the Note directory (NOTELIB_FILEPATH)
        /// </summary>
        /// <returns></returns>
        private List<String> getNoteFileList()
        {
            String[] noteFiles = Directory.GetFiles(NOTELIB_FILEPATH, "*.note", SearchOption.TopDirectoryOnly);

            List<String> noteFilesList = new List<string>();
            foreach (String file in noteFiles)
                noteFilesList.Add(Path.GetFileName(file));

            return noteFilesList;
        }

        /// <summary>
        /// Returns the contents of the note filename requested
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private List<String> getNoteFileContents(String filename)
        {
            List<String> fileContents = new List<String>();
            StreamReader sr = null;
            try
            {
                using (sr = new StreamReader(NOTELIB_FILEPATH + filename))
                {
                    while (sr.Peek() != -1)
                        fileContents.Add(sr.ReadLine());

                    sr.Close();

                    return fileContents;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to access the following note file: " + filename + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sr.Close();
                return new List<String>();
            }
            finally
            {
                sr.Close();
            }
        }

        /// <summary>
        /// Returns the next available filename 
        /// </summary>
        /// <returns></returns>
        private String getNextNoteFilename()
        {
            String[] noteFiles = Directory.GetFiles(NOTELIB_FILEPATH, "*.note", SearchOption.TopDirectoryOnly);
            if (noteFiles.Length == 0)
                return "1.note";

            // Get next available note#
            bool matchFound = false;
            for (int i = 1; i < 100; i++)
            {
                matchFound = false;
                foreach (String noteFilename in noteFiles)
                {
                    if (Path.GetFileName(noteFilename).Equals(i + ".note"))
                        matchFound = true;
                }

                if (!matchFound)
                    return i + ".note";
            }
            return "1.note";
        }

        /// <summary>
        /// Save a note
        /// </summary>
        /// <param name="noteText"></param>
        /// <param name="noteFilename"></param>
        /// <returns></returns>
        public bool saveNote(String noteText, String noteFilename="")
        {

            if (noteFilename.Length == 0)
                noteFilename = getNextNoteFilename();

           StreamWriter sw = null;
            try
            {
                using (sw = File.CreateText(NOTELIB_FILEPATH + noteFilename))
                {
                    FileInfo noteFile = new FileInfo(NOTELIB_FILEPATH + noteFilename);

                    sw.WriteLine(noteText);

                    sw.Close();

                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to save the note file." + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sw.Close();
                return false;
            }
            finally
            {
                sw.Close();
            } 

        }

        /// <summary>
        /// Deletes the requested noteFilename
        /// </summary>
        /// <param name="noteFilename"></param>
        /// <returns></returns>
        public bool discardNote(String noteFilename)
        {
            try
            {
                if (File.Exists(NOTELIB_FILEPATH + noteFilename))
                {
                    File.Delete(NOTELIB_FILEPATH + noteFilename);
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("An Error occurred while trying to discard the note file." + About.APP_CONTACT + "\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Opens all note files in a new note window
        /// </summary>
        public void openAllNotes()
        {
            // Open all note files. Start by getting note count from NoteLib. 
            NoteLib notelib = new NoteLib();
            List<String> noteFilesList = notelib.getNoteFileList();
            if (noteFilesList.Count > 0)
            {
                // Open all note files
                foreach (String filename in noteFilesList)
                {
                    NoteFile noteFile = new NoteFile();
                    noteFile.filename = filename;
                    noteFile.contents = notelib.getNoteFileContents(filename);

                    NoteWindow noteWin = new NoteWindow(noteFile);
                    noteWin.Show();
                }
            }
        }
    }
}
