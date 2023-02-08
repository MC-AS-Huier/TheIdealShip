using TheIdealShip.Modules;
using TheIdealShip.Roles;
using UnityEngine;
using Types = TheIdealShip.Modules.CustomOption.CustomOptionType;

namespace TheIdealShip
{
    public class CustomOptionHolder
    {
        public static string[] rates = new string[]{"0%","10%","20%","30%","40%","50%","60%","70%","80%","90%","100%"};
        public static string[] presets = new string[]{"Preset1","Preset2","Preset3" ,"Preset4" ,"Preset5" };
       // public static string[] modeset = new string[]{"Classic","FreePlay"};
        public static string cs(Color c, string s)
        {
            var Cs = Helpers.cs(c,s);
            return Cs;
        }
        public static Color GeneralColor = new Color(204f / 255f, 204f / 255f, 0, 1f);

        public static CustomOption presetSelection;
        public static CustomOption modeOption;
        public static CustomOption noGameEnd;
        public static CustomOption showExilePlayerRole;
        public static CustomOption showExilePlayerConcreteRoleTeam;
        public static CustomOption activateRoles;
        public static CustomOption crewmateRolesCountMin;
        public static CustomOption crewmateRolesCountMax;
        public static CustomOption neutralRolesCountMin;
        public static CustomOption neutralRolesCountMax;
        public static CustomOption impostorRolesCountMin;
        public static CustomOption impostorRolesCountMax;
        public static CustomOption modifierRolesCountMin;
        public static CustomOption modifierRolesCountMax;
        public static CustomOption disableHauntMenu;
        public static CustomOption PlayerOption;
        public static CustomOption PlayerGhostSpeed;
        public static CustomOption jiarennumber;
        public static CustomOption disableServerKickPlayer;

        public static CustomOption camouflagerSpawnRate;
        public static CustomOption camouflagerCooldown;
        public static CustomOption camouflagerDuration;

        public static CustomOption illusorySpawnRate;
        public static CustomOption illusoryCooldown;
        public static CustomOption illusoryDuration;
        
        public static CustomOption sheriffSpawnRate;
        public static CustomOption sheriffCooldown;
        public static CustomOption sheriffshootNumber;

        public static CustomOption jesterSpawnRate;
        public static CustomOption jesterCanCallEmergency;

        public static CustomOption flashSpawnRate;
        public static CustomOption flashSpeed;

        public static void Load()
        {

            presetSelection = CustomOption.Create(0, Types.General, cs(GeneralColor, "Preset"), presets, null, true);
            //modeOption = CustomOption.Create(1,Types.General,"GameMode",modeset,null,true);
            noGameEnd = CustomOption.Create(2, Types.General,cs(GeneralColor,"NoGameEnd"),false,null,true);
            jiarennumber = CustomOption.Create(16, Types.General, "jiaren", 0f, 0f, 15f, 1f);
            showExilePlayerRole = CustomOption.Create(3, Types.General, cs(GeneralColor,"ShowExilePlayerRole"), false,null,true);
            showExilePlayerConcreteRoleTeam = CustomOption.Create(17, Types.General, cs(GeneralColor,"ShowExilePlayerConcreteRoleTeam"),false,showExilePlayerRole);
            activateRoles = CustomOption.Create(4,Types.General,cs(GeneralColor,"Block Vanilla Roles"),true,null,true);

            crewmateRolesCountMin = CustomOption.Create(5, Types.General,cs(GeneralColor,"Minimum Crewmate Roles"),15f, 0f, 15f, 1f);
            crewmateRolesCountMax = CustomOption.Create(6, Types.General,cs(GeneralColor,"Maximum Crewmate Roles"),15f, 0f, 15f, 1f);
            neutralRolesCountMin = CustomOption.Create(7, Types.General,cs(GeneralColor,"Minimum Neutral Roles"),15f, 0f, 15f, 1f);
            neutralRolesCountMax = CustomOption.Create(8, Types.General,cs(GeneralColor,"Maximum Neutral Roles"),15f, 0f, 15f, 1f);
            impostorRolesCountMin = CustomOption.Create(9, Types.General, cs(GeneralColor, "Minimum Impostor Roles"), 15f, 0f, 15f, 1f);
            impostorRolesCountMax = CustomOption.Create(10, Types.General, cs(GeneralColor, "Maximum Impostor Roles"), 15f, 0f, 15f, 1f);
            modifierRolesCountMin = CustomOption.Create(11, Types.General, cs(GeneralColor, "Minimum Modifier Roles"), 15f, 0f, 15f, 1f);
            modifierRolesCountMax = CustomOption.Create(12, Types.General, cs(GeneralColor, "Maximum Modifier Roles"), 15f, 0f, 15f, 1f);

            PlayerOption = CustomOption.Create(14, Types.General, "PlayerOption", false, null, true);
            //disableHauntMenu = CustomOption.Create(13, Types.General, "disableHauntMenu", false, PlayerOption);
            PlayerGhostSpeed = CustomOption.Create(15, Types.General, "PlayerGhostSpeed", 3f, 1f, 10f, 0.5f, PlayerOption);
            disableServerKickPlayer = CustomOption.Create(18, Types.General, "disableServerKickPlayer", false, null, true);

            camouflagerSpawnRate = CustomOption.Create(50, Types.Impostor, cs(Camouflager.color, "Camouflager"), rates, null, true);
            camouflagerCooldown = CustomOption.Create(51, Types.Impostor, "Camouflager Cooldown", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            camouflagerDuration = CustomOption.Create(52, Types.Impostor, "Camouflager Duration", 10f, 5f, 20f, 1f, camouflagerSpawnRate);
            
            illusorySpawnRate = CustomOption.Create(60, Types.Impostor, cs(Illusory.color, "Illusory"), rates, null, true);
            illusoryCooldown = CustomOption.Create(61, Types.Impostor, "Illusory Cooldown", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            illusoryDuration = CustomOption.Create(62, Types.Impostor, "Illusory Duration", 10f, 5f, 20f, 1f, camouflagerSpawnRate);

            //                                     Id Tap分类            选项名                              父项   为父项
            sheriffSpawnRate = CustomOption.Create(20, Types.Crewmate, cs(Sheriff.color, "Sheriff"), rates, null, true);
            //                                    ID  Tap分类          选项名             默认 最小 最大 间隔   父项
            sheriffCooldown = CustomOption.Create(21, Types.Crewmate, "SheriffCooldown", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
            sheriffshootNumber = CustomOption.Create(22, Types.Crewmate, "ShootNumber", 5f,1f,15f,1f,sheriffSpawnRate);

            // 中立职业
            jesterSpawnRate = CustomOption.Create(150, Types.Neutral, cs(Jester.color, "Jester"), rates, null, true);
            jesterCanCallEmergency = CustomOption.Create(151, Types.Neutral, "CanCallEmergency", true, jesterSpawnRate);

            // modifier 附加职业
            flashSpawnRate = CustomOption.Create(100, Types.Modifier, cs(Flash.color, "Flash"), rates, null, true);
            flashSpeed = CustomOption.Create(101, Types.Modifier, "Speed", 5f, 1f, 10f, 0.5f, flashSpawnRate);
        }
    }
}