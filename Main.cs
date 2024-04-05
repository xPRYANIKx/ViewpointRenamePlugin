using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using PRYANIK_Plugin.Forms;

namespace PRYANIK_Plugin
{
    [Plugin("PRYANIK_Plugin", "хPRYANIKх", DisplayName = "PRYANIK_Plugin")]
    [RibbonLayout("PRYANIK_Plugin.xaml")]

    [RibbonTab("PluginTab", DisplayName = "PRYANIK_Plugin")]
    [Command("ID_Button_A", DisplayName = "Настройка для пакетного переименования точек обзора", Icon = "Source\\rename_small.png", LargeIcon = "Source\\rename_big.png", 
        ToolTip = "Настройка для пакетного переименования точек обзора.\nДля переименования точки обзора - задайте параметры в данном окне, после чего выберите необходимую точку обзора и " +
        "нажмите клавишу Q", CanToggle = true)]
    public class Main : CommandHandlerPlugin
    {
        public override int ExecuteCommand(string name, params string[] parameters)
        {
            switch (name)
            {
                case "ID_Button_A":
                    {
                        if (Application.ActiveDocument?.SavedViewpoints?.CurrentSavedViewpoint?.DisplayName != null)
                        {
                            RenameViewForm renameViewForm = new RenameViewForm();
                            renameViewForm.ShowDialog();
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return 0;
        }
    }
}

namespace PRYANIK_Plugin_inputPlugin
{
    [Plugin("PRYANIK_inputPlugin", "хPRYANIKх")]
    public class Main : InputPlugin
    {
        public override bool KeyUp(View view, KeyModifiers modifier, ushort key, double timeOffset)
        {
            if (Application.ActiveDocument?.SavedViewpoints?.CurrentSavedViewpoint?.DisplayName != null && key == 81)
            {
                RenameViewForm renameViewForm = new RenameViewForm();
                renameViewForm.RenameViewPointObj();
            }

            return base.KeyUp(view, modifier, key, timeOffset);
        }
    }
}