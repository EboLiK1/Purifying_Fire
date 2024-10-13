using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class LocalizationData
{
    public static string CURRENT_LANGUAGE = "Русский";

    public static Dictionary<string, Dictionary<string, string>> LOCALIZATION =
        new Dictionary<string, Dictionary<string, string>>()
        {
            #region UI

            #region Главное меню
            { "play_button", new Dictionary<string, string>()
                {
                    { "English", "Play" },
                    { "Русский", "Играть" }
                }
            },
            { "settings_button", new Dictionary<string, string>()
                {
                    { "English", "Settings" },
                    { "Русский", "Настройки" }
                }
            },
            { "extras_button", new Dictionary<string, string>()
                {
                    { "English", "Extras" },
                    { "Русский", "Дополнительно" }
                }
            },
            { "quit_button", new Dictionary<string, string>()
                {
                    { "English", "Quit" },
                    { "Русский", "Выход" }
                }
            },
            #endregion

            #region Меню паузы
            { "resume_button", new Dictionary<string, string>()
                {
                    { "English", "Resume" },
                    { "Русский", "Продолжить" }
                }
            },
            { "tips_button", new Dictionary<string, string>()
                {
                    { "English", "Tips" },
                    { "Русский", "Подсказки" }
                }
            },
            { "main_menu_button", new Dictionary<string, string>()
                {
                    { "English", "Main Menu" },
                    { "Русский", "Главное Меню" }
                }
            },
            #endregion

            #region Меню смерти
            { "press_restart", new Dictionary<string, string>()
                {
                    { "English", "Press any button to continue" },
                    { "Русский", "Нажмите любую кнопку, чтобы продолжить" }
                }
            },
            { "death_menu_label", new Dictionary<string, string>()
                {
                    { "English", "You died" },
                    { "Русский", "Вы погибли" }
                }
            },
            #endregion

            #region Настройки

            #region Названия меню
            { "pause_menu_label", new Dictionary<string, string>()
                {
                    { "English", "PAUSE" },
                    { "Русский", "ПАУЗА" }
                }
            },
            { "settings_menu_label", new Dictionary<string, string>()
                {
                    { "English", "SETTINGS" },
                    { "Русский", "НАСТРОЙКИ" }
                }
            },
            { "game_settings_menu_label", new Dictionary<string, string>()
                {
                    { "English", "GAME" },
                    { "Русский", "ИГРА" }
                }
            },
            { "video_settings_menu_label", new Dictionary<string, string>()
                {
                    { "English", "VIDEO" },
                    { "Русский", "ВИДЕО" }
                }
            },
            { "audio_settings_menu_label", new Dictionary<string, string>()
                {
                    { "English", "AUDIO" },
                    { "Русский", "АУДИО" }
                }
            },
            { "apply_label", new Dictionary<string, string>()
                {
                    { "English", "Apply" },
                    { "Русский", "Принять" }
                }
            },
            { "close_label", new Dictionary<string, string>()
                {
                    { "English", "Back" },
                    { "Русский", "Назад" }
                }
            },
            #endregion

            #region Настройки игры
            { "game_button", new Dictionary<string, string>()
                {
                    { "English", "Game" },
                    { "Русский", "Игра" }
                }
            },
            { "language_button", new Dictionary<string, string>()
                {
                    { "English", "Text Language" },
                    { "Русский", "Язык Текста" }
                }
            },
            { "controls_button", new Dictionary<string, string>()
                {
                    { "English", "Controls" },
                    { "Русский", "Управление" }
                }
            },

            #region Настройки управления

            { "press_key_to_rebind", new Dictionary<string, string>()
                {
                    { "English", "PRESS ANY KEY TO REBIND" },
                    { "Русский", "НАЖМИТЕ ЛЮБУЮ КЛАВИШУ ДЛЯ ПЕРЕНАЗНАЧЕНИЯ" }
                }
            },
            { "move_left_control", new Dictionary<string, string>()
                {
                    { "English", "Move Left" },
                    { "Русский", "Движение Влево" }
                }
            },
            { "move_right_control", new Dictionary<string, string>()
                {
                    { "English", "Move Right" },
                    { "Русский", "Движение Вправо" }
                }
            },
            { "crouch_control", new Dictionary<string, string>()
                {
                    { "English", "Crouch" },
                    { "Русский", "Присесть" }
                }
            },
            { "jump_control", new Dictionary<string, string>()
                {
                    { "English", "Jump" },
                    { "Русский", "Прыжок" }
                }
            },
            { "jumpoff_control", new Dictionary<string, string>()
                {
                    { "English", "Jump Off" },
                    { "Русский", "Спрыгнуть" }
                }
            },
            { "dash_control", new Dictionary<string, string>()
                {
                    { "English", "Dash" },
                    { "Русский", "Рывок" }
                }
            },
            { "attack_control", new Dictionary<string, string>()
                {
                    { "English", "Attack" },
                    { "Русский", "Атака" }
                }
            },
            { "interact_control", new Dictionary<string, string>()
                {
                    { "English", "Interact" },
                    { "Русский", "Взаимодействие" }
                }
            },
            
            #endregion

            #endregion

            #region Настройки видео
            { "video_button", new Dictionary<string, string>()
                {
                    { "English", "Video" },
                    { "Русский", "Видео" }
                }
            },
            #region Настройки видео
            { "music", new Dictionary<string, string>()
                {
                    { "English", "Music" },
                    { "Русский", "Мука" }
                }
            },
            { "effects", new Dictionary<string, string>()
                {
                    { "English", "Effects" },
                    { "Русский", "Эффекты" }
                }
            },
            { "resolution", new Dictionary<string, string>()
                {
                    { "English", "Resolution" },
                    { "Русский", "Разрешение" }
                }
            },
            #endregion
            
            #region Настройки звука
            { "audio_button", new Dictionary<string, string>()
                {
                    { "English", "Sound" },
                    { "Русский", "Звук" }
                }
            },
            #endregion

            #endregion

            #endregion

            #region Дополнительно

            { "extras_menu_label", new Dictionary<string, string>()
                {
                    { "English", "EXTRAS" },
                    { "Русский", "ДОПОЛНИТЕЛЬНО" }
                }
            },
            { "about_game_button", new Dictionary<string, string>()
                {
                    { "English", "About Game" },
                    { "Русский", "Об Игре" }
                }
            },
            { "about_game_label", new Dictionary<string, string>()
                {
                    { "English", "ABOUT GAME" },
                    { "Русский", "ОБ ИГРЕ" }
                }
            },
            { "title_button", new Dictionary<string, string>()
                {
                    { "English", "Titles" },
                    { "Русский", "Титры" }
                }
            },
            { "about_game_text", new Dictionary<string, string>()
                {
                    { "English", "Purifying Fire is a 2D pixel-art style computer game.\r\n\r\nThe story starts from the year 1102. You are an officer of the royal army of the country of Sacrinem. The undead have begun to appear in the north of the country, and you have not heard from Knight-Commander Pyrus, who was in charge of the northern region, for a long time. Your task is to solve the mystery of the appearance of the undead and the reason for the disappearance of Pirus.\r\n\r\nThis game was developed in cooperation with Dmitry Donskoy (scriptwriter)." },
                    { "Русский", "Purifying Fire - компьютерная 2D-игры в стиле пиксель-арт.\r\n\r\nИстория начинается с 1102 года. Вы являетесь офицером королевской армии страны Сакринем. На севере страны начала появляться нежить, а от рыцаря-командора Пируса, который отвечал за северный регион, уже давно нет вестей. Ваша задача разобраться с тайной появления нежити и с причиной пропажи Пируса.\r\n\r\nДанная игра была разработана при содействии с Дмитрием Донским (сценарист)." }
                }
            },
            #endregion

            #region Интро
            { "anonim_author", new Dictionary<string, string>()
                {
                    { "English", "Anonymous author" },
                    { "Русский", "Анонимный автор" }
                }
            },
            { "text2", new Dictionary<string, string>()
                {
                    { "English", "1102. The month of the Ring of Fire" },
                    { "Русский", "1102 год. Месяц \"Огненного кольца\"" }
                }
            },
            { "text3", new Dictionary<string, string>()
                {
                    { "English", "The undead have begun to appear in large numbers in the north of Sacrinem country" },
                    { "Русский", "На севере страны Сакринем в больших количествах начала появляться нежить" }
                }
            },
            { "text4", new Dictionary<string, string>()
                {
                    { "English", "There had been no word from Knight Commander Pyrus, who was in charge of the northern region, for a long time" },
                    { "Русский", "От рыцарь-командора Пируса, который отвечал за северный регион, давно нет вестей" }
                }
            },
            { "text5", new Dictionary<string, string>()
                {
                    { "English", "By the King's decision, you, officer, must travel north and discover the cause of the undead and Pyrus' disappearance" },
                    { "Русский", "По решению короля вы, офицер, должны отправиться на север и узнать причину появления нежити и пропажи Пируса" }
                }
            },
            { "text6", new Dictionary<string, string>()
                {
                    { "English", "After several months of travel, you arrive in the northern region and learn that the undead are appearing near Mount Perenius, where, according to the archives, there was a temple of Dei, abandoned since before the founding of the kingdom" },
                    { "Русский", "Спустя несколько месяцев пути вы прибываете в северный регион и узнаете, что нежить появляется около горы Перениус, где, согласно архивам, находился храм Деи, заброшенный еще со времен до основания королевства" }
                }
            },
            { "text7", new Dictionary<string, string>()
                {
                    { "English", "So you've been wandering around the mountains for days. Finally. You've found the temple, or rather, its ruins. Though ruined, its majestic size still amazes you" },
                    { "Русский", "И вот вы днями скитаетесь по горам и... Наконец-то. Вы нашли храм, точнее, его руины. Хоть он и разрушен, но его величественные размеры до сих пор удивляют" }
                }
            },
            { "text8", new Dictionary<string, string>()
                {
                    { "English", "After a short time, you find the entrance. You take a step and..." },
                    { "Русский", "Спустя короткое время вы нашли вход. Вы делаете шаг и..." }
                }
            },
            { "text9", new Dictionary<string, string>()
                {
                    { "English", "There should be an effect, like we're losing consciousness, but the shader doesn't work." },
                    { "Русский", "Тут должен быть эффект, типо мы теряем сознание, но шейдер не работает" }
                }
            },
            { "woke_up1", new Dictionary<string, string>()
                {
                    { "English", "After a while you woke up..." },
                    { "Русский", "Спустя некоторое время вы очнулись..." }
                }
            },
            { "boss_nachalo1", new Dictionary<string, string>()
                {
                    { "English", "You've been wandering the dungeon for hours and here it is again..." },
                    { "Русский", "Вы бродите по подземелью часам и вот опять..." }
                }
            },
            { "boss_nachalo2", new Dictionary<string, string>()
                {
                    { "English", "It's supposed to be a cool effect, like you faint, but the shader doesn't work" },
                    { "Русский", "Тут должен быть крутой эффект, типо вы падаете в обморок, но шейдер не работает" }
                }
            },
            { "boss_final", new Dictionary<string, string>()
                {
                    { "English", "A year later, a huge horde of undead swooped down not only on Sacrinem, but on the rest of the states as well" },
                    { "Русский", "Спустя год огромная орда нежити нахлынула не только Сакринем, но и на остальные государства" }
                }
            },
            #region Cathedral_1
            { "you_sleep", new Dictionary<string, string>()
                {
                    { "English", "Skip" },
                    { "Русский", "Пропустить" }
                }
            },
            { "skip", new Dictionary<string, string>()
                {
                    { "English", "Skip" },
                    { "Русский", "Пропустить" }
                }
            },
            #endregion

            #endregion

            #region Титры

            #endregion

            #region Подсказки
            { "press_f", new Dictionary<string, string>()
                {
                    { "English", "Press F" },
                    { "Русский", "Нажмите F" }
                }
            },
            { "move_tip1", new Dictionary<string, string>()
                {
                    { "English", "Movement" },
                    { "Русский", "Передвижение" }
                }
            },
            { "move_tip2", new Dictionary<string, string>()
                {
                    { "English", "A - Move left\r\nD - Move right\r\nSpace - Jump,\r\nCtrl - Crouch\r\nS - Jump off\r\nLeft Shift - Dash" },
                    { "Русский", "A - Движение влево\r\nD - Движение вправо\r\nSpace - Прыжок\r\nCtrl - Присесть\r\nS - Спрыгнуть\r\nLeft Shift - Рывок" }
                }
            },
            { "move_tip3", new Dictionary<string, string>()
                {
                    { "English", "All key bindings can be changed in settings in the main menu, or press ESC and go to settings -> control and change any binding." },
                    { "Русский", "Все привязки клавишь можно изменить в настройках в главном меню, либо нажать на ESC и перейти в меню настроек -> управление и изменить любую привязку." }
                }
            },
            { "inter_tip1", new Dictionary<string, string>()
                {
                    { "English", "Interation" },
                    { "Русский", "Взаимодействие" }
                }
            },
            { "inter_tip2", new Dictionary<string, string>()
                {
                    { "English", "E - Interaction" },
                    { "Русский", "E - Взаимодействие" }
                }
            },
            { "inter_tip3", new Dictionary<string, string>()
                {
                    { "English", "In the course of the game you will encounter objects that you can interact with. To activate them, you need to walk up to them and press the interaction button." },
                    { "Русский", "По ходу игры вы будете встречать объекты, с которыми можно взаимодействовать. Для активации нужно подойти и нажать кнопку взаимодействия." }
                }
            },
            { "inter_tip4", new Dictionary<string, string>()
                {
                    { "English", "All key bindings can be changed in settings in the main menu, or press ESC and go to settings -> control and change any binding." },
                    { "Русский", "Все привязки клавишь можно изменить в настройках в главном меню, либо нажать на ESC и перейти в меню настроек -> управление и изменить любую привязку." }
                }
            },
            { "enemy_tip1", new Dictionary<string, string>()
                {
                    { "English", "Enemies" },
                    { "Русский", "Враги" }
                }
            },
            { "enemy_tip2", new Dictionary<string, string>()
                {
                    { "English", "During the course of the game you will encounter various enemies. You can either engage in combat or bypass them. Be carefulб." },
                    { "Русский", "По ходу игры вам будут встречаться различные враги. Вы можете вступить в бой, либо обойти их. Будьте аккуратны." }
                }
            },
            { "attack_tip1", new Dictionary<string, string>()
                {
                    { "English", "Attack" },
                    { "Русский", "Атака" }
                }
            },
            { "attack_tip2", new Dictionary<string, string>()
                {
                    { "English", "LMB - Attack" },
                    { "Русский", "LMB - Атака" }
                }
            },
            { "attack_tip3", new Dictionary<string, string>()
                {
                    { "English", "Press repeatedly to perform a combo. Each attack in the combo has its own power, damage and area of effect." },
                    { "Русский", "Нажмите несколько раз, чтобы совершить комбо. Каждая атака в комбо имеет свою силу, урон и площадь пораженияю." }
                }
            },
            #endregion

            #endregion
        };

    public static string[] LANGUAGES = new string[] { "Русский", "English" };

    private static UnityEvent _onLanguageChanged;
    public static UnityEvent OnLanguageChanged
    {
        get
        {
            if (_onLanguageChanged == null)
                _onLanguageChanged = new UnityEvent();
            return _onLanguageChanged;
        }
    }
}