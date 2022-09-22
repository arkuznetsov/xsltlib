// Исполняемое приложение для запуска компоненты под отладчиком

// В проекте TestApp в "Ссылки" ("References") должен быть добавлен проект компоненты
// В проекте TestApp должны быть подключены NuGet пакеты OneScript и OneScript.Library

using System;
using ScriptEngine.HostedScript;
using ScriptEngine.HostedScript.Library;

namespace TestApp
{
	class MainClass : IHostApplication
	{

		static readonly string SCRIPT = @"// Отладочный скрипт
// в котором уже подключена наша компонента

Преобразование = Новый ПреобразованиеXSL();

СтрокаXSL = ""<?xml version = """"1.0"""" encoding=""""UTF-8""""?>
            |<xsl:stylesheet version = """"3.0"""" xmlns:xsl=""""http://www.w3.org/1999/XSL/Transform"""">
			|
			|	<xsl:output method=""""xml"""" indent=""""yes"""" />
			|	<xsl:template match="""" / """">
			|		<new>
			|			<xsl:value-of select=""""/root/item[last()]""""/>
			|		</new>
			|	</xsl:template>
			|</xsl:stylesheet>"";

СтрокаXML = ""<?xml version = """"1.0"""" encoding=""""UTF-8""""?>
			|
			|<root>
			|	<item>item1</item>
			|	<item>item2</item>
			|	<item>item3</item>
			|</root>"";

Преобразование.ЗагрузитьТаблицуСтилейXSLИзСтроки(СтрокаXSL);

Результат = Преобразование.ПреобразоватьИзСтроки(СтрокаXML);
Сообщить(Результат);
Сообщить(""Ок!"");
"
		;

		public static HostedScriptEngine StartEngine()
		{
			var engine = new HostedScriptEngine();
			engine.Initialize();

			// Тут можно указать любой класс из компоненты
			engine.AttachAssembly(System.Reflection.Assembly.GetAssembly(typeof(oscriptcomponent.XSLTransform)));

			// Если проектов компонент несколько, то надо взять по классу из каждой из них
			// engine.AttachAssembly(System.Reflection.Assembly.GetAssembly(typeof(oscriptcomponent_2.MyClass_2)));
			// engine.AttachAssembly(System.Reflection.Assembly.GetAssembly(typeof(oscriptcomponent_3.MyClass_3)));

			return engine;
		}

		public static void Main(string[] args)
		{
			var engine = StartEngine();
			var script = engine.Loader.FromString(SCRIPT);
			var process = engine.CreateProcess(new MainClass(), script);

			var result = process.Start(); // Запускаем наш тестовый скрипт

			Console.WriteLine("Result = {0}", result);

			// ВАЖНО: движок перехватывает исключения, для отладки можно пользоваться только точками останова.
		}

		public void Echo(string str, MessageStatusEnum status = MessageStatusEnum.Ordinary)
		{
			Console.WriteLine(str);
		}

		public void ShowExceptionInfo(Exception exc)
		{
			Console.WriteLine(exc.ToString());
		}

		public bool InputString(out string result, string prompt, int maxLen, bool multiline)
		{
			throw new NotImplementedException();
		}

		public string[] GetCommandLineArguments()
		{
			return new string[] { "1", "2", "3" }; // Здесь можно зашить список аргументов командной строки
		}
	}
}
