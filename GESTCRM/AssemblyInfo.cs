using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//
// La informaci�n general de un ensamblado se controla mediante el siguiente 
// conjunto de atributos. Cambie estos atributos para modificar la informaci�n
// asociada con un ensamblado.
//
[assembly: AssemblyTitle("GESTCRM")]
[assembly: AssemblyDescription("Gestion de Fuerza de Ventas")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Laboratorio STADA")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("2010 Laboratorio STADA")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//
// La informaci�n de versi�n de un ensamblado consta de los siguientes cuatro valores:
//
//      Versi�n principal
//      Versi�n secundaria 
//      Versi�n de compilaci�n
//      Revisi�n
//
// Puede especificar todos los valores o usar los valores predeterminados (n�mero de versi�n de compilaci�n y de revisi�n) 
// usando el s�mbolo '*' como se muestra a continuaci�n:

//[assembly: AssemblyVersion("2.3.0.62")] //Inactiva posiilidad de cambiar clasificaci�n y correge descarga clasificaci�n (solo 1 caracter)
//[assembly: AssemblyVersion("2.3.0.63")] //Caja/Enfajado por tipo pedido
//[assembly: AssemblyVersion("2.3.0.64")] // Nuevas condiciones 2023: descuento medio
//[assembly: AssemblyVersion("2.3.0.65")] // Corrige error fecha compromiso
[assembly: AssemblyVersion("2.3.0.66")] // Descuento en l�nea si configuraci�n


// Pantalla adapatada a nuevos port�tiles de GX NO, ESTA SER� LA 6x?

//
// Si desea firmar el ensamblado, debe especificar una clave para su uso. Consulte la documentaci�n de 
// Microsoft .NET Framework para obtener m�s informaci�n sobre la firma de ensamblados.
//
// Utilice los atributos siguientes para controlar qu� clave desea utilizar para firmar. 
//
// Notas: 
//   (*) Si no se especifica ninguna clave, el ensamblado no se firma.
//   (*) KeyName se refiere a una clave instalada en el Proveedor de servicios
//       de cifrado (CSP) en el equipo. KeyFile se refiere a un archivo que contiene
//       una clave.
//   (*) Si se especifican los valores KeyFile y KeyName, tendr� 
//       lugar el siguiente proceso:
//       (1) Si KeyName se puede encontrar en el CSP, se utilizar� dicha clave.
//       (2) Si KeyName y KeyFile no existen, se instalar� 
//           y utilizar� la clave de KeyFile en el CSP.
//   (*) Para crear KeyFile, puede ejecutar la utilidad sn.exe (Strong Name).
//       Cuando se especifica KeyFile, la ubicaci�n de KeyFile debe ser
//       relativa al directorio de resultados del proyecto, que es
//       %Directorio del proyecto%\obj\<configuraci�n>. Por ejemplo, si KeyFile
//       se encuentra en el directorio del proyecto, el atributo AssemblyKeyFile se especifica 
//       como [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Firma retardada es una opci�n avanzada; consulte la documentaci�n de
//       Microsoft .NET Framework para obtener m�s informaci�n.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
[assembly: ComVisibleAttribute(false)]
