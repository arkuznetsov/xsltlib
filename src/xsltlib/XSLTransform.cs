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

        /// <summary>
        /// Загружает таблицу стилей XSL
        /// </summary>
        /// <param name="xmlReader">ЧтениеXML. Объект чтения XML, из которого будет загружена таблица стилей XSL.</param>
        [ContextMethod("ЗагрузитьТаблицуСтилей", "LoadXSLStylesheet")]
        public void LoadXSLStylesheet(XmlReaderImpl xmlReader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Загружает таблицу стилей XSL
        /// </summary>
        /// <param name="xmlString">Строка. Строка, содержащая описание преобразования XSL.</param>
        [ContextMethod("ЗагрузитьТаблицуСтилейXSLИзСтроки ", "LoadXSLStylesheetFromString")]
        public void LoadXSLStylesheetFromString(string xmlString)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Загружает описание преобразования XSL из узла DOM.
        /// </summary>
        /// <param name="domNode">УзелDOM. Узел DOM, представляющий собой шаблон XSL.</param>
        [ContextMethod("ЗагрузитьТаблицуСтилейXSLИзУзла ", "LoadXSLStylesheetFromNode")]
        public void LoadXSLStylesheetFromNode(IValue domNode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Загружает описание преобразования XSL из файла.
        /// </summary>
        /// <param name="fileName">Строка. Имя файла, из которого должно быть загружено описание преобразования XSL.</param>
        [ContextMethod("ЗагрузитьТаблицуСтилейXSLИзФайла ", "LoadXSLStylesheetFromFile")]
        public void LoadXSLStylesheetFromFile(string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Очищает внутреннее состояние.
        /// </summary>
        [ContextMethod("Очистить", "Clear")]
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполняет преобразование XML-документа.
        /// Используется описание преобразования и значения параметров, ранее установленные в данном объекте.
        /// </summary>
        /// <param name="xmlReader">ЧтениеXML. Объект чтения XML, из которого будет прочитан исходный XML документ для преобразования.</param>
        /// <param name="xmlWriter">ЧтениеXML. Объект записи XML, в который будет записан результат преобразования.</param>
        [ContextMethod("Преобразовать", "Transform")]
        public void Transform(XmlReaderImpl xmlReader, XmlWriterImpl xmlWriter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполняет преобразование XML-документа.
        /// Используется описание преобразования и значения параметров, ранее установленные в данном объекте.
        /// </summary>
        /// <param name="xmlString">Строка. Строка, в которой находится XML-документ.</param>
        /// <param name="xmlWriter">ЧтениеXML. Объект записи XML, в который будет записан результат преобразования.
        /// Указание данного параметра имеет смысл, если преобразование выполняется в документ XML.
        /// При указании данного параметра результат преобразования будет записываться в объект ЗаписьXML,
        /// возвращаемое значение в данном случае будет отсутствовать.</param>
        /// <returns>Строка. Результат преобразования.</returns>
        [ContextMethod("ПреобразоватьИзСтроки", "TransformFromString")]
        public string TransformFromString(string xmlString, XmlWriterImpl xmlWriter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполняет преобразование XML-документа.
        /// Используется описание преобразования и значения параметров, ранее установленные в данном объекте.
        /// </summary>
        /// <param name="domNode">УзелDOM. Узел DOM - исходное дерево для преобразования XSL.</param>
        /// <param name="xmlWriter">ЧтениеXML. Объект записи XML, в который будет записан результат преобразования.
        /// Указание данного параметра имеет смысл, если преобразование выполняется в документ XML.
        /// При указании данного параметра результат преобразования будет записываться в объект ЗаписьXML,
        /// возвращаемое значение в данном случае будет отсутствовать.</param>
        /// <returns>Строка. Результат преобразования.</returns>
        [ContextMethod("ПреобразоватьИзУзла", "TransformFromNode")]
        public string TransformFromNode(IValue domNode, XmlWriterImpl xmlWriter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Выполняет преобразование XML-документа.
        /// Используется описание преобразования и значения параметров, ранее установленные в данном объекте.
        /// </summary>
        /// <param name="fileName">Строка. Имя файла, в котором находится преобразуемый XML-документ.</param>
        /// <param name="xmlWriter">ЧтениеXML. Объект записи XML, в который будет записан результат преобразования.
        /// Указание данного параметра имеет смысл, если преобразование выполняется в документ XML.
        /// При указании данного параметра результат преобразования будет записываться в объект ЗаписьXML,
        /// возвращаемое значение в данном случае будет отсутствовать.</param>
        /// <returns>Строка. Результат преобразования.</returns>
        [ContextMethod("ПреобразоватьИзФайла", "TransformFromFile")]
        public string TransformFromFile(string fileName, XmlWriterImpl xmlWriter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Задает значение параметра преобразования.
        /// </summary>
        /// <param name="fullName">Строка. Полное имя параметра.</param>
        /// <param name="value">Булево, Число, Строка. Значение параметра.</param>
        [ContextMethod("УдалитьПараметр", "AddParameter")]
        public void AddParameter(string fullName, IValue value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаляет значение параметра.
        /// </summary>
        /// <param name="fullName">Строка. Полное имя параметра.</param>
        [ContextMethod("ДобавитьПараметр", "RemoveParameter")]
        public void RemoveParameter(string fullName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создает ИзвлечениеДанныхJSON
        /// </summary>
        /// <returns>ИзвлечениеДанныхJSON</returns>
        [ScriptConstructor]
        public static IRuntimeContextInstance Constructor()
        {
            return new XSLTransform();
        }
    }
}