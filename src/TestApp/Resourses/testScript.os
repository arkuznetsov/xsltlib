// Отладочный скрипт
// в котором уже подключена наша компонента

Преобразование = Новый ПреобразованиеXSL();

СтрокаXSL = "<?xml version = ""1.0"" encoding=""UTF-8""?>
            |<xsl:stylesheet version = ""3.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
            |
            |	<xsl:output method=""xml"" indent=""yes"" />
            |	<xsl:template match="" / "">
            |		<new>
            |			<xsl:value-of select=""/root/item[last()]""/>
            |		</new>
            |	</xsl:template>
            |</xsl:stylesheet>";

СтрокаXML = "<?xml version = ""1.0"" encoding=""UTF-8""?>
            |
            |<root>
            |	<item>item1</item>
            |	<item>item2</item>
            |	<item>item3</item>
            |</root>";

Преобразование.ЗагрузитьТаблицуСтилейXSLИзСтроки(СтрокаXSL);

Результат = Преобразование.ПреобразоватьИзСтроки(СтрокаXML);
Сообщить(Результат);
Сообщить("Ок!");