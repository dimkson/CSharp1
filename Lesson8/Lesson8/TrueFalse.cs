using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Lesson8
{
    [Serializable]
    class Question
    {
        string text;
        bool trueFalse;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public bool TrueFalse
        {
            get { return trueFalse; }
            set { trueFalse = value; }
        }
        public Question(string text, bool trueFalse)
        {
            this.text = text;
            this.trueFalse = trueFalse;
        }
        public Question()
        {

        }
    }
    class TrueFalse
    {
        List<Question> list;
        string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public TrueFalse(string fileName)
        {
            list = new List<Question>();
            this.fileName = fileName;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            serializer.Serialize(fs, list);
            fs.Close();
        }
        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            list = (List<Question>)serializer.Deserialize(fs);
            fs.Close();
        }
    }
}
