using System;
using System.Xml;

namespace CheckXmlSerialization
{
    /// <summary>
    /// 指定されたファイルがXmlの形式として正しいかを検証する
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 読み出し対象のファイルを指定：ファイル内で指定しない場合は引数から取得。
            var filePath = "";
            if (string.IsNullOrEmpty(filePath))
            {
                if (args.Length == 0) { Console.WriteLine("読み込み対象のファイルを選択してください"); return; }
                filePath = args[1];
            }
            #endregion

            // 特別なルールを設定する場合、「XmlReaderSettings」クラスを使用する。
            XmlReaderSettings settings = new XmlReaderSettings();
            // 検証は「整形式かどうか」の検査のみ
            settings.ConformanceLevel = ConformanceLevel.Document;

            // 「XmlReader」の作成
            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                try
                {
                    while (reader.Read()) { }
                }
                catch (Exception e) { Console.WriteLine(e.Message); return; }
            }
            Console.WriteLine("問題無し");
        }
    }
}
