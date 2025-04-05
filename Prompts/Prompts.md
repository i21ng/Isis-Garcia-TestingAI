# Isis-Garcia-TestingAI
Proyecto Final - Modelo VIAG QA 4.0

## ARTEFACTOS DE PRUEBAS

1. **Documento de casos de prueba**
CasosPrueba.xlsx

2. **Documento de seguimiento de errores**
SeguimientoErrores.xlsx

## REQUERIMIENTOS

1. **Idea de proyecto de software**
Sistema para registro de insumos de una panadería.

2. **Modelo de lenguaje**
Gemini

3. **Prompt para generar requerimientos funcionales y no funcionales**
Como especialista en calidad de software, entrégame un listado de los requerimientos funcionales y no funcionales para validación de un sistema de registro y consulta de insumos de una panadería, lista únicamente los requerimientos para los módulos de registro y consulta de insumos.

Nombre archivo: _RequerimientosGestiónInsumos_

4. **Casos de prueba de aceptación**
Ayúdame a generar una tabla con todos los casos de prueba de aceptación de los requisitos funcionales y no funcionales del documento adjunto.

Se guardan casos de prueba en archivo _CasosPrueba_

## PRUEBAS DE ACEPTACIÓN
1. **Modelo de lenguaje**
Gemini / Chat GPT

2. **Invalidación de requerimientos**
Se modifica el archivo _RequerimientosGestiónInsumos_ agregando los siguientes puntos:
- El nombre del insumo solo debe permitir captura de letras
- El sistema no debe permitir eliminar registros
- El costo unitario debe registrarse como valor entero
- El sistema solo permitirá la exportación de reportes en formato CSV

3. **Propmt casos de prueba vs requerimiento modificado**

Como experta en pruebas y calidad de software, aplica los casos de prueba del archivo xlsx al requerimiento documentado en el PDF y apóyame a identificar si existe alguna contradicción o ambigüedad que deba considerar para asegurar la calidad de las pruebas . Gemini

compara los archivos adjuntos e indícame si se están contemplando todas las pruebas mínimas necesarias para validación de los requerimientos funcionales y no funcionales definidos, si encuentras alguna inconsistencia, ambigüedad o contradicción en el requerimiento, también indícalo. Chat GPT

4. **Registro de errores en _SeguimientoErrores_**
Se agregan los siguientes errores:
NE65498_1
NE65498_2
NE65498_3
NE65498_4
NE65498_5
NE65498_6
NE65498_7
NE65498_8
NE65498_9
NE65498_10
NE65498_11

## DISEÑO DEL SISTEMA

1. **Prompt casos de uso**
Genera todos los casos de uso posibles para los requerimientos funcionales y no funcionales del documento adjunto, de preferencia organizados en una tabla. Gemini

Nombre archivo: Casos_de_Uso.xlsx

2. **Prompt interfaces de usuario**
Genera todas las interfases de usuario necesarias para el requerimiento del archivo adjunto. Gemini

Nombre archivo: Interfaz de usuario.PDF

3. **Prompt casos de prueba para _RequerimientosGestiónInsumos_ y casos de uso**
Se modifica RequerimientosGestiónInsumos, agregando al final del documento los casos de uso.

Prompt:

Como ingeniero de calidad y pruebas de software, genera todos los casos de prueba de sistema necesarios para cubrir el alcance del requerimiento en los archivos adjuntos. En ellos encontrarás los requerimientos funcionales y no funcionales del sistema, así como los casos de uso e interfases de usuario. De ser posible, organiza la información en una tabla considerando id, prioridad de la prueba, título, descripción, módulo, tipo de prueba, resultado esperado.
Chat GPT

4. **Casos de prueba generados**
Se agregan casos de prueba al documento _CasosPrueba_

## PRUEBAS DE SISTEMA

1. **Alteración casos de uso e interfaces de usuario**

Alteración de archivo _Casos_de_Uso_:
- Se cambia descripción del CU002 a "No se permite modificar los datos de un insumo existente".
- Se cambia descripción del CU004 a "Se muestra un listado de todos los insumos existentes".
- Se cambia descripción del CU006 a "Permite exportar reportes generados en formato PDF".
- Se cambia descripción del CU010 a "Permite el uso simultáneo de hasta 100 usuarios".

Alteración de archivo _Interfaz de usuario_:

Inicio de sesión:
- Se agrega el siguiente punto al flujo de interacción: "Se colocará el código de verificación en un campo nuevo que aparecerá en la pantalla".

Registro de insumos:
- Se agrega característica de obligatoriedad a los siguientes elementos:
-- Proveedor
-- Categoría
-- Cantidad mínima para alerta

2. **Modelo de lenguaje**
Perplexity

3. **Prompts casos de prueba vs casos de uso e interfaces de usuario**

Como experta en pruebas y calidad de software, aplica los casos de prueba del archivo xlsx a los casos de uso e interfases de usuario en los otros documentos y apóyame a identificar si existe alguna contradicción o ambigüedad que deba considerar para asegurar la calidad de las pruebas

puedes organizar estos hallazgos en una tabla?

4. **Registro de errores en _SeguimientoErrores_**

Se agregan los siguientes errores al documento:
NE65498_12
NE65498_13
NE65498_14
NE65498_15
NE65498_16
NE65498_17
NE65498_18

## DISEÑO DE ARQUITECTURA

1. **Prompt diseño arquitectura**
Como ingeniero de calidad y pruebas de software, crea el diseño de arquitectura correspondiente a los requerimientos funcionales y no funcionales definidos en el archivo adjunto y considerando que deben generarse diagramas de infraestructura, de componentes y de bases de datos.

De los diagramas descritos anteriormente, entrégame el código para generarlos en mermaid.

Gemini

Archivo de diagrama de infraestructura:diagramaInfraestructura.png
Archivo de diagrama de componentes: diagramaComponentes.png
Archivo de diagrama de bases de datos: diagramaBaseDatos.jpg
Archivo de los 3 diagramas: diagramasArq.png
Archivo diagramas mermaid: diagramasMermaid.docx

2. **Prompt casos de prueba de diagramas**
Genera una tabla con todos los casos de pruebas de integración necesarios para el requerimiento definido en los diagramas del archivo adjunto. 

Perplexity

Se guardan casos de prueba en archivo _CasosPrueba_

## PRUEBAS DE INTEGRACIÓN

1. **Alteraciones a diagramas de arquitectura**

- Diagrama de infraestructura: 
-- Se elimina relación del servidor de aplicaciones con el servidor de base de datos.

- Diagrama de base de datos: 
-- Se elimina tipo de dato del campo id_insumo en tabla de Insumos
-- Se elimina campo de proveedor en tabla de Insumos
-- Se elimina campo de contraseña en tabla de Usuarios

- Diagrama de componentes:
-- Se elimina módulo de autenticación.
-- Se elimina módulo de reportes.

2. **Modelo de lenguaje**
Perplexity

3. **Prompt casos de prueba vs diagramas modificados**
Como experta en pruebas y calidad de software, aplica los casos de prueba del archivo xlsx a los diagramas de infraestructura, componentes y base de datos del PDF y apóyame a identificar si existe alguna contradicción o ambigüedad que deba considerar para asegurar la calidad de las pruebas. De ser posible entrega la información en una tabla. 

4. **Registro de errores en _SeguimientoErrores_**

Se agregan los siguientes errores al documento:
NE65498_19
NE65498_20
NE65498_21
NE65498_22
NE65498_23
NE65498_24
NE65498_25

## DISEÑO MODULAR

1. **Prompt diagramas de clases y de flujo**
Como ingeniero de calidad y pruebas de software, crea un diagrama de clases y un diagrama de flujo correspondientes a los requerimientos funcionales y no funcionales definidos en el archivo adjunto. De ser posible genera el código para mermaid. 

Perplexity 

Archivo diagramas: diagramasClasesFlujoPerplexity.png
Archivo diagramas mermaid: diagramasClasesFlujoMermaid.docx

2. **Prompt casos de pruebas de diagramas**

Como ingeniera de pruebas y calidad de software, genera todos los casos de pruebas necesarios para cubrir el requerimiento definido en los diagramas de clases y de flujo de la imagen adjunta. De ser posible, genera una tabla de los casos de prueba considerando las siguientes columnas: id, prioridad de la prueba, título, descripción, módulo, tipo de prueba, resultado esperado. 

Perplexity

3. **Casos de prueba generados**
Se agregan casos de prueba al documento _CasosPrueba_

## PRUEBAS UNITARIAS

1. **Modelo de lenguaje**
Chat GPT

2/3. **Prompt código de clases y pruebas unitarias**

Dame todos los pasos y código necesarios para implementar TDD en la lógica de "Crear insumo" considerando los campos de la imagen adjunta. Utiliza Visual Studio como IDE, C# como lenguaje de programación y NUnit como framework de testing en un proyecto de consola.

Dame un paso a la vez y pregúntame si puedes continuar antes de decirme el siguiente paso.

4. **Alteraciones al código**
- Se modifica InsumoTests.cs línea 83 para indicar una cantidad negativa a la prueba.
- Se modifica InsumoTests.cs línea 112 para indicar que el insumo actualizado es el que tiene id 9

5. **Registro de errores en _SeguimientoErrores_**

Se agregan los siguientes errores al documento:
NE65498_26
NE65498_27

## CLASIFICACIÓN

1. **Modelo de lenguaje**
Chat GPT

2. **Prompt severidad y tipos de error**
Como experta en pruebas y calidad de software, ayúdame a asignar un grado de severidad de los errores en el archivo adjunto y clasifícalos por tipo de error. Entrégame el resultado en una tabla.

Archivo generado: erroresClasificados.CSV

## PRUEBAS AUTOMATIZADAS

1. Acciones de usuario para formulario de registro en https://webcore.zell.mx/

2. Código para pruebas automatizadas con NUnit
Se incluye solo un registro considerando la captura de todos los campos obligatorios, quedó pendiente generar el código para pruebas de error y validación de datos.

3. Código en playwright y ZeroStep con Cursor - Quedó pendiente.















