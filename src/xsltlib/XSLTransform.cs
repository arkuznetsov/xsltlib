/*----------------------------------------------------------
Use of this source code is governed by an MIT-style
license that can be found in the LICENSE file or at
https://opensource.org/licenses/MIT.
----------------------------------------------------------
// Codebase: https://github.com/ArKuznetsov/xsltlib/
----------------------------------------------------------*/

using System;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.HostedScript.Library.Xml;
using System.Xml;
using System.Xml.Xsl;

namespace oscriptcomponent
{
    /// <summary>
    /// Предназначен для преобразования текстов XML.
    /// </summary>
    [ContextClass("ПреобразованиеXSL", "XSLTransform")]
    public class XSLTransform : AutoContext<XSLTransform>
    {
        private XslCompiledTransform _xslTransform;
        private XsltArgumentList _argumentList;

        /// <summary>
        /// Загружает таблицу стилей XSL
        /// </summary>
        /// <param name="xmlReader">ЧтениеXML. Объект чтения XML, из которого будет загружена таблица стилей XSL.</param>
        [ContextMethod("ЗагрузитьТаблицуСтилей", "LoadXSLStylesheet")]
        public void LoadXSLStylesheet(XmlReaderImpl xmlReader)
        {
            _xslTransform.Load(xmlReader.GetNativeReader());
        }

        /// <summary>
        /// Загружает таблицу стилей XSL
        /// </summary>
        /// <param name="xmlString">Строка. Строка, содержащая описание преобразования XSL.</param>
        [ContextMethod("ЗагрузитьТаблицуСтилейXSLИзСтроки", "LoadXSLStylesheetFromString")]
        public void LoadXSLStylesheetFromString(string xmlString)
        {
            XmlReaderImpl _reader = new XmlReaderImpl();

            _reader.SetString(xmlString);

            LoadXSLStylesheet(_reader);
        }

        /// <summary>
        /// Загружает описание преобразования XSL из узла DOM.
        /// </summary>
        /// <param name="domNode">УзелDOM. Узел DOM, представляющий собой шаблон XSL.</param>
        [ContextMethod("ЗагрузитьТаблицуСтилейXSLИзУзла", "LoadXSLStylesheetFromNode")]
        public void LoadXSLStylesheetFromNode(IValue domNode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Загружает описание преобразования XSL из файла.
        /// </summary>
        /// <param name="fileName">Строка. Имя файла, из которого должно быть загружено описание преобразования XSL.</param>
        [ContextMethod("ЗагрузитьТаблицуСтилейXSLИзФайла", "LoadXSLStylesheetFromFile")]
        public void LoadXSLStylesheetFromFile(string fileName)
        {
            XmlReaderImpl _reader = new XmlReaderImpl();

            _reader.OpenFile(fileName);

            LoadXSLStylesheet(_reader);
        }

        /// <summary>
        /// Очищает внутреннее состояние.
        /// </summary>
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            _xslTransform = new XslCompiledTransform();
            _argumentList = new XsltArgumentList();
        }

        /// <summary>
        /// Выполняет преобразование XML-документа.
        /// Используется описание преобразования и значения параметров, ранее установленные в данном объекте.
        /// </summary>
        /// <param name="xmlReader">ЧтениеXML. Объект чтения XML, из которого будет прочитан исходный XML документ для преобразования.</param>
        /// <param name="xmlWriter">ЗаписьXML. Объект записи XML, в который будет записан результат преобразования.</param>
        [ContextMethod("Преобразовать", "Transform")]
        public void Transform(XmlReaderImpl xmlReader, XmlWriterImpl xmlWriter)
        {

            XmlReader _reader = xmlReader.GetNativeReader();
            XmlWriter _writer = xmlWriter.GetNativeWriter();

            _xslTransform.Transform(_reader, _argumentList, _writer);
        }

        /// <summary>
        /// Выполняет преобразование XML-документа.
        /// Используется описание преобразования и значения параметров, ранее установленные в данном объекте.
        /// </summary>
        /// <param name="xmlString">Строка. Строка, в которой находится XML-документ.</param>
        /// <param name="xmlWriter">ЗаписьXML. Объект записи XML, в который будет записан результат преобразования.
        /// Указание данного параметра имеет смысл, если преобразование выполняется в документ XML.
        /// При указании данного параметра результат преобразования будет записываться в объект ЗаписьXML,
        /// возвращаемое значение в данном случае будет отсутствовать.</param>
        /// <returns>Строка. Результат преобразования.</returns>
        [ContextMethod("ПреобразоватьИзСтроки", "TransformFromString")]
        public string TransformFromString(string xmlString, XmlWriterImpl xmlWriter = null)
        {
            XmlReaderImpl _reader = new XmlReaderImpl();

            _reader.SetString(xmlString);

            XmlWriterImpl _writer = new XmlWriterImpl();
            _writer.SetString();

            Transform(_reader, _writer);

            string result = _writer.Close().ToString();

            if (xmlWriter != null)
                xmlWriter.WriteRaw(result);

            return result;
        }

        /// <summary>
        /// Выполняет преобразование XML-документа.
        /// Используется описание преобразования и значения параметров, ранее установленные в данном объекте.
        /// </summary>
        /// <param name="domNode">УзелDOM. Узел DOM - исходное дерево для преобразования XSL.</param>
        /// <param name="xmlWriter">ЗаписьXML. Объект записи XML, в который будет записан результат преобразования.
        /// Указание данного параметра имеет смысл, если преобразование выполняется в документ XML.
        /// При указании данного параметра результат преобразования будет записываться в объект ЗаписьXML,
        /// возвращаемое значение в данном случае будет отсутствовать.</param>
        /// <returns>Строка. Результат преобразования.</returns>
        [ContextMethod("ПреобразоватьИзУзла", "TransformFromNode")]
        public IValue TransformFromNode(IValue domNode, XmlWriterImpl xmlWriter = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполняет преобразование XML-документа.
        /// Используется описание преобразования и значения параметров, ранее установленные в данном объекте.
        /// </summary>
        /// <param name="fileName">Строка. Имя файла, в котором находится преобразуемый XML-документ.</param>
        /// <param name="xmlWriter">ЗаписьXML. Объект записи XML, в который будет записан результат преобразования.
        /// Указание данного параметра имеет смысл, если преобразование выполняется в документ XML.
        /// При указании данного параметра результат преобразования будет записываться в объект ЗаписьXML,
        /// возвращаемое значение в данном случае будет отсутствовать.</param>
        /// <returns>Строка. Результат преобразования.</returns>
        [ContextMethod("ПреобразоватьИзФайла", "TransformFromFile")]
        public string TransformFromFile(string fileName, XmlWriterImpl xmlWriter = null)
        {
            XmlReaderImpl _reader = new XmlReaderImpl();

            _reader.OpenFile(fileName);

            XmlWriterImpl _writer = new XmlWriterImpl();
            _writer.SetString();

            Transform(_reader, _writer);

            string result = _writer.Close().ToString();

            if (xmlWriter != null)
                xmlWriter.WriteRaw(result);

            return result;
        }

        /// <summary>
        /// Добавляет значение параметра преобразования.
        /// </summary>
        /// <param name="fullName">Строка. Полное имя параметра.</param>
        /// <param name="value">Булево, Число, Строка. Значение параметра.</param>
        [ContextMethod("ДобавитьПараметр", "AddParameter")]
        public void AddParameter(string fullName, IValue value)
        {

            switch (value.DataType)
            {
                case DataType.Boolean:
                    _argumentList.AddParam(fullName, "", value.AsBoolean());
                    break;
                case DataType.Number:
                    _argumentList.AddParam(fullName, "", value.AsNumber());
                    break;
                case DataType.String:
                    _argumentList.AddParam(fullName, "", value.AsString());
                    break;
                default:
                    _argumentList.AddParam(fullName, "", value.AsObject());
                    break;
            }
        }

        /// <summary>
        /// Удаляет значение параметра преобразования.
        /// </summary>
        /// <param name="fullName">Строка. Полное имя параметра.</param>
        [ContextMethod("УдалитьПараметр", "RemoveParameter")]
        public void RemoveParameter(string fullName)
        {
            _argumentList.RemoveParam(fullName, "");
        }

        /// <summary>
        /// Создает XSLTransform
        /// </summary>
        /// <returns>XSLTransform</returns>
        public XSLTransform()
        {
            _xslTransform = new XslCompiledTransform();
            _argumentList = new XsltArgumentList();
        }

        /// <summary>
        /// Создает ПреобразованиеXSL
        /// </summary>
        /// <returns>ПреобразованиеXSL</returns>
        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new XSLTransform();
        }
    }
}