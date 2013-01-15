﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Threading;

namespace Ildss
{
    class Indexer
    {
        private int filesIndexed    { get; set; }
        private int totalFiles { get; set; }
        
        public void IndexFiles(string path)
        {
            filesIndexed = 0;
            totalFiles = System.IO.Directory.GetFiles(path, "*", SearchOption.AllDirectories).Count();

            if (System.IO.File.Exists(path))
            {
                IndexFile(path);
            }
            else if (System.IO.Directory.Exists(path))
            {
                IndexDirectory(path);
            }
        }

        // Recursively index subdirectories
        private void IndexDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = System.IO.Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                IndexFile(fileName);
            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = System.IO.Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                IndexDirectory(subdirectory);
        }

        public void IndexFile(string path)
        {
            FileInfo fi = new FileInfo(path);
            ++filesIndexed;

            // Hash File
            Hash h = new Hash();
            string fileHash = h.HashFile(fi.FullName);

            // Insert File into Index Database
            using (FileIndexContainer fic = new FileIndexContainer())
            {
                // Check if document exists in db
                var result = from documents in fic.Documents
                             where documents.DocumentHash == fileHash
                             select documents;

                // Check if path exists in db
                var pathResult = from docpaths in fic.DocPaths
                                 where docpaths.DocumentDocumentHash == fileHash && docpaths.path == path
                                 select docpaths;

               // New Document
                Document doc = new Document()
                {
                    DocumentHash = fileHash,
                    size = fi.Length
                };

                // New Path (hash not already in db)
                DocPath dp = new DocPath()
                {
                    path = fi.FullName
                };

                // New Path (hash already in db)
                DocPath dp2 = new DocPath()
                {
                    path = fi.FullName,
                    DocumentDocumentHash = fileHash
                };

                // If Document isn't Duplicate
                if (result.Count() == 0)
                {
                    fic.Documents.Add(doc);
                    doc.DocPaths.Add(dp);   //page 267/8 in Entity framework 4.0 recipes
                }
                else 
                // Document is duplicate
                {
                    // If path not already in database
                    if (pathResult.Count() == 0)
                    {
                        fic.DocPaths.Add(dp2);                    
                    }
                }
                fic.SaveChanges();
            }

            Console.WriteLine("Saved " + fi.FullName + " to database");
        }


        public void RegisterEvent(FileSystemEventArgs e)
        {
            var t = DateTime.Now;
            var time = t.AddTicks(-(t.Ticks % TimeSpan.TicksPerSecond));

            Thread.Sleep(2000);

            using (FileIndexContainer fic = new FileIndexContainer())
            {
                var docPaths = from docpaths in fic.DocPaths
                               where docpaths.path == e.FullPath
                               select docpaths;

                var docPathDefault = docPaths.FirstOrDefault();

                var doc = from documents in fic.Documents
                          where documents.DocumentHash == docPathDefault.DocumentDocumentHash
                          select documents;

                var ev = from events in fic.DocEvents
                         where events.date_time.CompareTo(time) == 0
                         select events;

                if (docPathDefault != null)
                {

                    // Event doesn't exist (events have unique times)
                    if (ev.Count() == 0)
                    {
                        DocEvent de = new DocEvent()
                        {
                            date_time = time,
                            type = e.ChangeType.ToString(),
                            DocumentDocumentHash = docPathDefault.Document.DocumentHash
                        };
                        fic.DocEvents.Add(de);
                        fic.SaveChanges();
                    }
                }
            }

        }

    }
}
