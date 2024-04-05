# ViewpointRenamePlugin

<p align="center">
  <img src="https://github.com/xPRYANIKx/ViewpointRenamePlugin/assets/92644479/4e097af5-fed3-4af6-ab23-78955326dfca">
</p>  
<p>Плагин для <b>Autodesk Navisworks</b>, который поможет пакетно переименовать имена точек обзора.</p>  

---
## Принцип работы
1. В открытой модели пользователю необходимо выбрать любую имеющуюся точку обзора на панели **"Сохранённые точки обзора"**
2. После этого пользователю необходимо нажать кнопку **"ViewPoinsRename Setting"** на панели **"PRYANIK_Plugin"**
    
**Примечание:** имена кнопок можно задать в файлах **"Main.cs"** и **"ru-RU/PRYANIK_Plugin.xaml"**. 

3. В открывшемся окне **"Переименование точек обзора"** можно выбрать следующие параметры:
<p align="center">
  <img src="https://github.com/xPRYANIKx/ViewpointRenamePlugin/assets/92644479/81ef01e0-32d5-4fbb-82eb-87ecfacb5e92">
</p>  
<ul>
<li><b>Этажи</b> - фиксированный параметр, который не меняется в процессе переименования имён точек обзора;</li>
<li><b>Номер</b> - численный параметр в формате <b>000</b>, который увеличивается на единицу с каждым переименованным именем точки обзора. Первое значение всегда необходимо задавать в виде <b>000</b>;</li>
<li><b>Постфикс</b> - имя переименовываемой точки обзора: параметр уникальный для каждой точки обзора;</li>
<li><b>Выбранные точки обзора</b> - отображение выбранной точки обзора. Функция отображения имён нескольких выделенных точек обзора не реализована;</li>
</ul>

**Важно:** стандартными способами нет возможности получить несколько выделенных точек обзора. При выделении мы всегда получаем последнюю выделенную точку обзора.    
**Примечание:** имена параметров, а так же их поведение можно задать в файле **"Forms/RenameViewForm.xaml.cs"**. Внешний вид окна задаётся в файле **"Forms/RenameViewForm.xaml"**

4. Выбираем любую точку обзора на панели **"Сохранённые точки обзора"** и нажимаем на клавиатуре клавишу **"Q"**: точка обзора будет переименована согласно установленным ранее правилам. Далее можно продолжать процесс переименования таким же образом,
   но не вызывая диалоговое окно **"Переименование точек обзора"**.
<p align="center">
  <img src="https://github.com/xPRYANIKx/ViewpointRenamePlugin/assets/92644479/a97ce598-c632-4aaa-b224-f8d606b85786">
</p>    

**Примечание:** другую горячую клавишу можно задать в файле **"Main.cs"** *(Q - key == 81)*. Подробнее читать [здесь](https://learn.microsoft.com/ru-ru/office/vba/language/reference/user-interface-help/keycode-constants).

```c#
public override bool KeyUp(View view, KeyModifiers modifier, ushort key, double timeOffset)
        {
            if (Application.ActiveDocument?.SavedViewpoints?.CurrentSavedViewpoint?.DisplayName != null && key == 81)
            {
                RenameViewForm renameViewForm = new RenameViewForm();
                renameViewForm.RenameViewPointObj();
            }

            return base.KeyUp(view, modifier, key, timeOffset);
        }
```
