# Oscript JSON data extractor component

[![GitHub release](https://img.shields.io/github/release/ArKuznetsov/xsltlib.svg?style=flat-square)](https://github.com/ArKuznetsov/xsltlib/releases)
[![GitHub license](https://img.shields.io/github/license/ArKuznetsov/xsltlib.svg?style=flat-square)](https://github.com/ArKuznetsov/xsltlib/blob/master/LICENSE)
[![GitHub Releases](https://img.shields.io/github/downloads/ArKuznetsov/xsltlib/latest/total?style=flat-square)](https://github.com/ArKuznetsov/xsltlib/releases)
[![GitHub All Releases](https://img.shields.io/github/downloads/ArKuznetsov/xsltlib/total?style=flat-square)](https://github.com/ArKuznetsov/xsltlib/releases)

[![Build Status](https://img.shields.io/github/workflow/status/ArKuznetsov/xsltlib/%D0%9A%D0%BE%D0%BD%D1%82%D1%80%D0%BE%D0%BB%D1%8C%20%D0%BA%D0%B0%D1%87%D0%B5%D1%81%D1%82%D0%B2%D0%B0)](https://github.com/arkuznetsov/xsltlib/actions/)
[![Quality Gate](https://open.checkbsl.org/api/project_badges/measure?project=xsltlib&metric=alert_status)](https://open.checkbsl.org/dashboard/index/xsltlib)
[![Coverage](https://open.checkbsl.org/api/project_badges/measure?project=xsltlib&metric=coverage)](https://open.checkbsl.org/dashboard/index/xsltlib)
[![Tech debt](https://open.checkbsl.org/api/project_badges/measure?project=xsltlib&metric=sqale_index)](https://open.checkbsl.org/dashboard/index/xsltlib)

## Компонента преобразования данных XML с использованием XSLT для oscript

## Примеры использования

### Преобразование строки XML

* таблица преобразования из строки
* результат в виде строки

```bsl
#Использовать xsltlib

ТаблицаСтилей = "<?xml version = ""1.0"" encoding=""UTF-8""?>
                |<xsl:stylesheet version = ""3.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
                |
                |  <xsl:output method=""xml"" indent=""yes"" />
                |  <xsl:template match="" / "">
                |    <new>
                |      <xsl:value-of select=""/root/item[last()]""/>
                |    </new>
                |  </xsl:template>
                |</xsl:stylesheet>";

СтрокаXML = "<?xml version = ""1.0"" encoding=""UTF-8""?>
            |
            |<root>
            |  <item>item1</item>
            |  <item>item2</item>
            |  <item>item3</item>
            |</root>";

```bsl
#Использовать xsltlib

Преобразование = Новый ПреобразованиеXSL();
Преобразование.ЗагрузитьТаблицуСтилейИзСтроки(ТаблицаСтилей);

Результат = Преобразование.ПреобразоватьИзСтроки(СтрокаXML);
Сообщить(Результат);

// > <new>item3</new>
```

### Преобразование файла XML (таблица преобразования из файла)

* таблица преобразования из файла
* результат в запись XML (файл)

```xml
<!-- stylesheet.xslt -->

<?xml version = "1.0" encoding="UTF-8"?>

<xsl:stylesheet version = "3.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" />
  <xsl:template match=" / ">
    <new>
      <xsl:value-of select="/root/item[last()]"/>
    </new>
  </xsl:template>
</xsl:stylesheet>
```

```xml
<!-- data.xml -->

<?xml version = "1.0" encoding="UTF-8"?>

<root>
  <item>item1</item>
  <item>item2</item>
  <item>item3</item>
</root>
```

```bsl
#Использовать xsltlib

Преобразование = Новый ПреобразованиеXSL();
Преобразование.ЗагрузитьТаблицуСтилейИзФайла("stylesheet.xslt");

Запись = Новый ЗаписьXML();
Запись.ОткрытьФайл("result.xml");

Результат = Преобразование.ПреобразоватьИзФайла("stylesheet.xslt", Запись);

```

```xml
<!-- result.xml -->

<new>item3</new>
```
