using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace FileSync
{
    public class ProjectFile
    {
        public string FilePath { get; set; }

        public void Load(out List<SyncItem> syncItems)
        {
            XDocument xDocument = XDocument.Load(FilePath, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            List<SyncItem> items = (from r in xDocument.Element("FileSync").Elements("SyncItem")
                                    select new SyncItem()
                                    {
                                        TargetFile = (string)r.Attribute("TargetFile"),
                                        WorkingFile = (string)r.Attribute("WorkingFile"),
                                    }).ToList();

            syncItems = items;
        }

        public void Create()
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                XDocument documentElement = new XDocument(new XElement("FileSync"));

                documentElement.Save(FilePath);
            }
        }

        public void Save(List<SyncItem> syncItems)
        {
            XDocument xmlDocument = XDocument.Load(FilePath, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            XElement xElement = xmlDocument.Element("FileSync");
            xElement.Nodes().Remove();

            foreach (SyncItem item in syncItems)
            {
                xElement.Add(new XElement("SyncItem",
                    new XAttribute("TargetFile", item.TargetFile),
                    new XAttribute("WorkingFile", item.WorkingFile)
                    ));
            }

            xmlDocument.Save(FilePath);

        }
    }
}
