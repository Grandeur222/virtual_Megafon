using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

#if NAUDIO
using NAudio.CoreAudioApi;
using NAudio.Dsp;
using NAudio.Wave;
#endif

namespace megafon
{
    internal static class UiText
    {
        private static readonly Dictionary<string, string[]> translations = new Dictionary<string, string[]>
        {
            { "Dil / Language", new[] { "Dil / Language", "Language", "Язык", "Langue" } },
            { "Mikrofon kontrolü  •  Sesini ayarla, kaydet", new[] { "Mikrofon kontrolü  •  Sesini ayarla, kaydet", "Microphone control  •  Adjust and record", "Управление микрофоном  •  Настройка и запись", "Contrôle du microphone  •  Réglez et enregistrez" } },
            { "Ses aygıtları", new[] { "Ses aygıtları", "Audio devices", "Аудиоустройства", "Périphériques audio" } },
            { "Mikrofon girişi", new[] { "Mikrofon girişi", "Microphone input", "Вход микрофона", "Entrée microphone" } },
            { "Ses çıkışı", new[] { "Ses çıkışı", "Audio output", "Аудиовыход", "Sortie audio" } },
            { "Ses geliştirme", new[] { "Ses geliştirme", "Sound enhancement", "Обработка звука", "Amélioration du son" } },
            { "Bas", new[] { "Bas", "Bass", "Бас", "Basses" } },
            { "Düşük", new[] { "Düşük", "Low", "Низкие", "Graves" } },
            { "Orta", new[] { "Orta", "Mid", "Средние", "Médiums" } },
            { "Yüksek", new[] { "Yüksek", "High", "Высокие", "Aigus" } },
            { "Sound booster", new[] { "Sound booster", "Sound booster", "Усиление звука", "Amplification" } },
            { "EQ bantları ve bas: -12 / +12 dB", new[] { "EQ bantları ve bas: -12 / +12 dB", "EQ bands and bass: -12 / +12 dB", "Полосы эквалайзера и бас: -12 / +12 дБ", "Bandes EQ et basses : -12 / +12 dB" } },
            { "Windows uygulama sesleri", new[] { "Windows uygulama sesleri", "Windows app audio", "Звук приложений Windows", "Audio des applications Windows" } },
            { "Ses çalan uygulama", new[] { "Ses çalan uygulama", "Playing application", "Воспроизводящее приложение", "Application en lecture" } },
            { "Ses seviyesi", new[] { "Ses seviyesi", "Volume", "Громкость", "Volume" } },
            { "Yenile", new[] { "Yenile", "Refresh", "Обновить", "Actualiser" } },
            { "Sessiz", new[] { "Sessiz", "Mute", "Без звука", "Muet" } },
            { "Uygulamaya özel EQ için sanal ses aygıtı/driver gerekir; Windows burada yalnızca ses ve sessiz kontrolü sağlar.", new[] { "Uygulamaya özel EQ için sanal ses aygıtı/driver gerekir; Windows burada yalnızca ses ve sessiz kontrolü sağlar.", "Per-app EQ requires a virtual audio device/driver; Windows only allows volume and mute control here.", "Для эквалайзера отдельного приложения требуется виртуальное аудиоустройство/драйвер; здесь Windows позволяет менять только громкость и отключать звук.", "L'égaliseur par application nécessite un périphérique audio virtuel/pilote ; Windows ne permet ici que le volume et la sourdine." } },
            { "Ses çalan uygulamalar aranıyor...", new[] { "Ses çalan uygulamalar aranıyor...", "Searching for apps playing audio...", "Поиск приложений с воспроизведением звука...", "Recherche des applications qui diffusent du son..." } },
            { "Profiller", new[] { "Profiller", "Profiles", "Профили", "Profils" } },
            { "Kayıtlı profil", new[] { "Kayıtlı profil", "Saved profile", "Сохранённый профиль", "Profil enregistré" } },
            { "Profil adı", new[] { "Profil adı", "Profile name", "Название профиля", "Nom du profil" } },
            { "Profili yükle", new[] { "Profili yükle", "Load profile", "Загрузить профиль", "Charger le profil" } },
            { "Profili kaydet", new[] { "Profili kaydet", "Save profile", "Сохранить профиль", "Enregistrer le profil" } },
            { "10 saniyelik kayıt", new[] { "10 saniyelik kayıt", "10-second recording", "Запись 10 секунд", "Enregistrement de 10 secondes" } },
            { "Kayıtların kaydedileceği klasör", new[] { "Kayıtların kaydedileceği klasör", "Recording folder", "Папка для записей", "Dossier d'enregistrement" } },
            { "Klasör seç", new[] { "Klasör seç", "Choose folder", "Выбрать папку", "Choisir un dossier" } },
            { "Mikrofonu Başlat", new[] { "Mikrofonu Başlat", "Start microphone", "Включить микрофон", "Démarrer le micro" } },
            { "Durdur", new[] { "Durdur", "Stop", "Остановить", "Arrêter" } },
            { "10 sn Kayıt", new[] { "10 sn Kayıt", "Record 10 sec", "Запись 10 сек", "Enregistrer 10 s" } },
            { "Kaydı Durdur ve Kaydet", new[] { "Kaydı Durdur ve Kaydet", "Stop and save recording", "Остановить и сохранить", "Arrêter et enregistrer" } },
            { "Durum: Hazır", new[] { "Durum: Hazır", "Status: Ready", "Статус: Готово", "État : Prêt" } },
            { "MEGAFON | Mikrofon ve Ses Kontrolü", new[] { "MEGAFON | Mikrofon ve Ses Kontrolü", "MEGAFON | Microphone & Audio Control", "MEGAFON | Управление микрофоном и звуком", "MEGAFON | Contrôle du microphone et du son" } },
            { "Lütfen mikrofon ve çıkış aygıtı seçin.", new[] { "Lütfen mikrofon ve çıkış aygıtı seçin.", "Please select a microphone and an output device.", "Выберите микрофон и устройство вывода.", "Veuillez sélectionner un microphone et une sortie audio." } },
            { "Aygıt seçimi", new[] { "Aygıt seçimi", "Device selection", "Выбор устройства", "Sélection du périphérique" } },
            { "Mikrofon aktarımı açık", new[] { "Mikrofon aktarımı açık", "Microphone monitoring is on", "Передача с микрофона включена", "Écoute du microphone activée" } },
            { "Mikrofon aktarımı başlatılamadı: ", new[] { "Mikrofon aktarımı başlatılamadı: ", "Could not start microphone monitoring: ", "Не удалось включить передачу с микрофона: ", "Impossible de démarrer l'écoute du microphone : " } },
            { "Ses hatası", new[] { "Ses hatası", "Audio error", "Ошибка звука", "Erreur audio" } },
            { "Kayıttan önce mikrofon aktarımını başlatın.", new[] { "Kayıttan önce mikrofon aktarımını başlatın.", "Start microphone monitoring before recording.", "Перед записью включите передачу с микрофона.", "Démarrez l'écoute du microphone avant l'enregistrement." } },
            { "Bilgi", new[] { "Bilgi", "Information", "Информация", "Information" } },
            { "Önce kayıt klasörünü seçin.", new[] { "Önce kayıt klasörünü seçin.", "Choose a recording folder first.", "Сначала выберите папку для записей.", "Choisissez d'abord un dossier d'enregistrement." } },
            { "Kayıt yapılıyor (en fazla 10 saniye)", new[] { "Kayıt yapılıyor (en fazla 10 saniye)", "Recording (up to 10 seconds)", "Идёт запись (до 10 секунд)", "Enregistrement (10 secondes maximum)" } },
            { "Kayıt başlatılamadı: ", new[] { "Kayıt başlatılamadı: ", "Could not start recording: ", "Не удалось начать запись: ", "Impossible de démarrer l'enregistrement : " } },
            { "Kayıt hatası", new[] { "Kayıt hatası", "Recording error", "Ошибка записи", "Erreur d'enregistrement" } },
            { "Geçici kayıt dosyası bulunamadı.", new[] { "Geçici kayıt dosyası bulunamadı.", "Temporary recording file was not found.", "Временный файл записи не найден.", "Le fichier d'enregistrement temporaire est introuvable." } },
            { "Kaydedildi: ", new[] { "Kaydedildi: ", "Saved: ", "Сохранено: ", "Enregistré : " } },
            { "Durum: Kayıt kaydedilemedi", new[] { "Durum: Kayıt kaydedilemedi", "Status: Recording could not be saved", "Статус: Не удалось сохранить запись", "État : Échec de l'enregistrement" } },
            { "Kayıt kaydedilemedi: ", new[] { "Kayıt kaydedilemedi: ", "Could not save recording: ", "Не удалось сохранить запись: ", "Impossible d'enregistrer : " } },
            { "Ses üreten uygulama bulunamadı. Uygulama ses çalarken listeyi yenileyin.", new[] { "Ses üreten uygulama bulunamadı. Uygulama ses çalarken listeyi yenileyin.", "No audio-playing apps found. Refresh while an app is playing audio.", "Приложения с активным звуком не найдены. Обновите список во время воспроизведения.", "Aucune application audio détectée. Actualisez pendant la lecture." } },
            { " aktif uygulama bulundu.", new[] { " aktif uygulama bulundu.", " active applications found.", " активных приложений найдено.", " applications actives trouvées." } },
            { "Uygulama sesi: ", new[] { "Uygulama sesi: ", "App audio: ", "Звук приложения: ", "Audio de l'application : " } },
            { "Uygulama sesleri alınamadı: ", new[] { "Uygulama sesleri alınamadı: ", "Could not read app audio sessions: ", "Не удалось получить аудиосеансы приложений: ", "Impossible de lire les sessions audio : " } },
            { "Ses seviyesi değiştirilemedi: ", new[] { "Ses seviyesi değiştirilemedi: ", "Could not change volume: ", "Не удалось изменить громкость: ", "Impossible de modifier le volume : " } },
            { "Sessiz durumu değiştirilemedi: ", new[] { "Sessiz durumu değiştirilemedi: ", "Could not change mute state: ", "Не удалось изменить состояние звука: ", "Impossible de modifier la sourdine : " } },
            { "10 saniyelik kayıtların kaydedileceği klasörü seçin.", new[] { "10 saniyelik kayıtların kaydedileceği klasörü seçin.", "Choose where 10-second recordings will be saved.", "Выберите папку для сохранения 10-секундных записей.", "Choisissez où enregistrer les clips de 10 secondes." } },
            { "Profil için bir ad girin.", new[] { "Profil için bir ad girin.", "Enter a name for the profile.", "Введите имя профиля.", "Saisissez un nom de profil." } },
            { "Profil", new[] { "Profil", "Profile", "Профиль", "Profil" } },
            { "Profil kaydedildi: ", new[] { "Profil kaydedildi: ", "Profile saved: ", "Профиль сохранён: ", "Profil enregistré : " } },
            { "Profil diske kaydedilemedi.", new[] { "Profil diske kaydedilemedi.", "Could not save profile to disk.", "Не удалось сохранить профиль на диск.", "Impossible d'enregistrer le profil sur le disque." } },
            { "Yüklenecek bir profil seçin.", new[] { "Yüklenecek bir profil seçin.", "Select a profile to load.", "Выберите профиль для загрузки.", "Sélectionnez un profil à charger." } },
            { "Profil yüklendi: ", new[] { "Profil yüklendi: ", "Profile loaded: ", "Профиль загружен: ", "Profil chargé : " } },
            { "Ayarlar kaydedilemedi: ", new[] { "Ayarlar kaydedilemedi: ", "Could not save settings: ", "Не удалось сохранить настройки: ", "Impossible d'enregistrer les paramètres : " } },
            { "Ayar dosyası okunamadı: ", new[] { "Ayar dosyası okunamadı: ", "Could not read settings file: ", "Не удалось прочитать файл настроек: ", "Impossible de lire le fichier de paramètres : " } },
            { "Durum: Mikrofon aktarımı açık", new[] { "Durum: Mikrofon aktarımı açık", "Status: Microphone monitoring is on", "Статус: Передача с микрофона включена", "État : Écoute du microphone activée" } },
            { "Durum: Kayıt yapılıyor (en fazla 10 saniye)", new[] { "Durum: Kayıt yapılıyor (en fazla 10 saniye)", "Status: Recording (up to 10 seconds)", "Статус: Идёт запись (до 10 секунд)", "État : Enregistrement (10 secondes maximum)" } },
            { "Ayarlar", new[] { "Ayarlar", "Settings", "Настройки", "Paramètres" } },
            { "Ses özelliklerini kullanmak için NAudio NuGet paketini yükleyin.", new[] { "Ses özelliklerini kullanmak için NAudio NuGet paketini yükleyin.", "Install the NAudio NuGet package to use audio features.", "Установите пакет NAudio NuGet для использования аудиофункций.", "Installez le package NuGet NAudio pour utiliser les fonctions audio." } },
            { "Eksik bağımlılık", new[] { "Eksik bağımlılık", "Missing dependency", "Отсутствует зависимость", "Dépendance manquante" } }
        };

        public static string DetectSystemLanguage()
        {
            string language = CultureInfo.CurrentUICulture.Name;
            if (language.StartsWith("ru", StringComparison.OrdinalIgnoreCase)) return "ru";
            if (language.StartsWith("fr", StringComparison.OrdinalIgnoreCase)) return "fr";
            if (language.StartsWith("en", StringComparison.OrdinalIgnoreCase)) return "en";
            return "tr";
        }

        public static bool IsSupported(string language)
        {
            return language == "tr" || language == "en" || language == "ru" || language == "fr";
        }

        public static string Get(string language, string key)
        {
            string[] values;
            if (!translations.TryGetValue(key, out values)) return key;
            int index = language == "en" ? 1 : language == "ru" ? 2 : language == "fr" ? 3 : 0;
            return values[index];
        }
    }

#if NAUDIO
    [Serializable]
    public class AudioProfile
    {
        public string Name { get; set; }
        public int Bass { get; set; }
        public int EqLow { get; set; }
        public int EqMid { get; set; }
        public int EqHigh { get; set; }
        public int Booster { get; set; }
    }

    [Serializable]
    public class AppSettingsData
    {
        public string RecordingDirectory { get; set; }
        public string Language { get; set; }
        public List<AudioProfile> Profiles { get; set; } = new List<AudioProfile>();
    }
#endif

    public partial class Form1 : Form
    {
#if NAUDIO
        private sealed class AppAudioSession : IDisposable
        {
            public uint ProcessId { get; private set; }
            public string DisplayName { get; private set; }
            public AudioSessionControl Session { get; private set; }
            public SimpleAudioVolume Volume { get; private set; }

            public AppAudioSession(AudioSessionControl session, uint processId, string displayName)
            {
                Session = session;
                ProcessId = processId;
                DisplayName = displayName;
                Volume = session.SimpleAudioVolume;
            }

            public override string ToString()
            {
                return DisplayName + "  (" + ProcessId + ")";
            }

            public void Dispose()
            {
                Volume?.Dispose();
                Session?.Dispose();
            }
        }

        private const int SampleRate = 44100;
        private string currentLanguage = UiText.DetectSystemLanguage();
        private readonly Dictionary<Control, string> originalControlText = new Dictionary<Control, string>();
        private readonly object audioProcessingLock = new object();
        private readonly object writerLock = new object();
        private readonly string settingsFilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Megafon", "settings.xml");
        private WaveInEvent waveIn;
        private WaveOutEvent waveOut;
        private BufferedWaveProvider bufferedProvider;
        private WaveFileWriter writer;
        private BiQuadFilter bassFilter;
        private BiQuadFilter lowFilter;
        private BiQuadFilter midFilter;
        private BiQuadFilter highFilter;
        private AppSettingsData settings = new AppSettingsData();
        private bool isPassthrough;
        private bool isRecording;
        private bool isLoadingSettings;
        private int boosterDb;
        private bool isRefreshingAppSessions;
        private readonly List<AppAudioSession> appAudioSessions = new List<AppAudioSession>();
        private System.Windows.Forms.Timer appRefreshTimer;
        private string tempWavPath;
        private string finalWavPath;

        public Form1()
        {
            InitializeComponent();
            foreach (ToolStripMenuItem languageItem in languageMenu.DropDownItems)
            {
                languageItem.Click += LanguageItem_Click;
            }
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
            btnPassthrough.Click += BtnPassthrough_Click;
            btnRecord.Click += BtnRecord_Click;
            btnBrowseFolder.Click += BtnBrowseFolder_Click;
            btnSaveProfile.Click += BtnSaveProfile_Click;
            btnLoadProfile.Click += BtnLoadProfile_Click;
            cbProfiles.SelectedIndexChanged += CbProfiles_SelectedIndexChanged;
            recordTimer.Tick += RecordTimer_Tick;
            btnRefreshApps.Click += BtnRefreshApps_Click;
            cbApps.SelectedIndexChanged += CbApps_SelectedIndexChanged;
            tbAppVolume.Scroll += TbAppVolume_Scroll;
            chkAppMute.CheckedChanged += ChkAppMute_CheckedChanged;
            appRefreshTimer = new System.Windows.Forms.Timer { Interval = 2500 };
            appRefreshTimer.Tick += AppRefreshTimer_Tick;
            tbBass.Scroll += AudioSetting_Scroll;
            tbEqLow.Scroll += AudioSetting_Scroll;
            tbEqMid.Scroll += AudioSetting_Scroll;
            tbEqHigh.Scroll += AudioSetting_Scroll;
            tbBoost.Scroll += AudioSetting_Scroll;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(settingsFilePath))
                {
                    using (FileStream stream = File.OpenRead(settingsFilePath))
                    {
                        settings = (AppSettingsData)new XmlSerializer(typeof(AppSettingsData)).Deserialize(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                settings = new AppSettingsData();
                MessageBox.Show(T("Ayar dosyası okunamadı: ") + ex.Message, T("Ayarlar"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (settings == null) settings = new AppSettingsData();
            if (settings.Profiles == null) settings.Profiles = new List<AudioProfile>();
            if (UiText.IsSupported(settings.Language)) currentLanguage = settings.Language;
            ApplyLanguage();
            if (string.IsNullOrWhiteSpace(settings.RecordingDirectory))
                settings.RecordingDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "Megafon");

            isLoadingSettings = true;
            txtRecordingDirectory.Text = settings.RecordingDirectory;
            cbProfiles.Items.Clear();
            foreach (AudioProfile profile in settings.Profiles)
            {
                if (profile != null && !string.IsNullOrWhiteSpace(profile.Name)) cbProfiles.Items.Add(profile.Name);
            }
            isLoadingSettings = false;

            for (int n = 0; n < WaveInEvent.DeviceCount; n++)
            {
                WaveInCapabilities caps = WaveInEvent.GetCapabilities(n);
                cbInput.Items.Add(n + ": " + caps.ProductName);
            }
            if (cbInput.Items.Count > 0) cbInput.SelectedIndex = 0;

            for (int n = 0; n < WaveOut.DeviceCount; n++)
            {
                WaveOutCapabilities caps = WaveOut.GetCapabilities(n);
                cbOutput.Items.Add(n + ": " + caps.ProductName);
            }
            if (cbOutput.Items.Count > 0) cbOutput.SelectedIndex = 0;

            UpdateAudioSettingLabels();
            UpdateAudioProcessingSettings();
            RefreshAppSessions();
            appRefreshTimer.Start();
        }

        private string T(string text)
        {
            return UiText.Get(currentLanguage, text);
        }

        private void LanguageItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string language = item?.Tag as string;
            if (!UiText.IsSupported(language) || language == currentLanguage) return;

            currentLanguage = language;
            ApplyLanguage();
            SaveSettings();
        }

        private void ApplyLanguage()
        {
            ApplyLanguageToControls(this);
            Text = T("MEGAFON | Mikrofon ve Ses Kontrolü");
            languageMenu.Text = T("Dil / Language");
            foreach (ToolStripMenuItem item in languageMenu.DropDownItems)
                item.Checked = (string)item.Tag == currentLanguage;
            btnPassthrough.Text = T(isPassthrough ? "Durdur" : "Mikrofonu Başlat");
            btnRecord.Text = T(isRecording ? "Kaydı Durdur ve Kaydet" : "10 sn Kayıt");
            lblStatus.Text = T(isRecording ? "Durum: Kayıt yapılıyor (en fazla 10 saniye)" :
                isPassthrough ? "Durum: Mikrofon aktarımı açık" : "Durum: Hazır");
            UpdateAudioSettingLabels();
            if (cbApps.SelectedItem != null) UpdateSelectedAppControls();
            else lblAppStatus.Text = T("Ses çalan uygulamalar aranıyor...");
        }

        private void ApplyLanguageToControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (!originalControlText.ContainsKey(control)) originalControlText.Add(control, control.Text);
                control.Text = T(originalControlText[control]);
                ApplyLanguageToControls(control);
            }
        }

        private void BtnPassthrough_Click(object sender, EventArgs e)
        {
            if (isPassthrough) StopPassthrough();
            else StartPassthrough();
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            if (isRecording) StopRecordingAndSave();
            else StartRecording();
        }

        private void RecordTimer_Tick(object sender, EventArgs e)
        {
            recordTimer.Stop();
            if (isRecording) StopRecordingAndSave();
        }

        private void StartPassthrough()
        {
            if (cbInput.SelectedIndex < 0 || cbOutput.SelectedIndex < 0)
            {
                MessageBox.Show(T("Lütfen mikrofon ve çıkış aygıtı seçin."), T("Aygıt seçimi"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                waveIn = new WaveInEvent
                {
                    DeviceNumber = GetSelectedDeviceIndex(cbInput.SelectedItem.ToString()),
                    WaveFormat = new WaveFormat(SampleRate, 16, 1),
                    BufferMilliseconds = 50
                };
                waveIn.DataAvailable += WaveIn_DataAvailable;
                bufferedProvider = new BufferedWaveProvider(waveIn.WaveFormat) { DiscardOnBufferOverflow = true };

                waveOut = new WaveOutEvent { DeviceNumber = GetSelectedDeviceIndex(cbOutput.SelectedItem.ToString()) };
                waveOut.Init(bufferedProvider);
                waveOut.Play();
                waveIn.StartRecording();

                isPassthrough = true;
                btnPassthrough.Text = T("Durdur");
                lblStatus.Text = T("Durum: Mikrofon aktarımı açık");
            }
            catch (Exception ex)
            {
                CleanupAudio();
                MessageBox.Show(T("Mikrofon aktarımı başlatılamadı: ") + ex.Message, T("Ses hatası"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopPassthrough()
        {
            if (isRecording) StopRecordingAndSave();
            try
            {
                waveIn?.StopRecording();
                waveOut?.Stop();
            }
            finally
            {
                CleanupAudio();
                isPassthrough = false;
                btnPassthrough.Text = T("Mikrofonu Başlat");
                if (!isRecording) lblStatus.Text = T("Durum: Hazır");
            }
        }

        private void StartRecording()
        {
            if (!isPassthrough || waveIn == null)
            {
                MessageBox.Show(T("Kayıttan önce mikrofon aktarımını başlatın."), T("Bilgi"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string directory = txtRecordingDirectory.Text.Trim();
                if (string.IsNullOrWhiteSpace(directory)) throw new InvalidOperationException(T("Önce kayıt klasörünü seçin."));
                Directory.CreateDirectory(directory);
                string fileName = "Megafon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + ".wav";
                finalWavPath = Path.Combine(directory, fileName);
                tempWavPath = Path.Combine(directory, "." + fileName + ".tmp");
                lock (writerLock) writer = new WaveFileWriter(tempWavPath, waveIn.WaveFormat);
                isRecording = true;
                btnRecord.Text = T("Kaydı Durdur ve Kaydet");
                btnBrowseFolder.Enabled = false;
                txtRecordingDirectory.Enabled = false;
                lblStatus.Text = T("Durum: Kayıt yapılıyor (en fazla 10 saniye)");
                recordTimer.Interval = 10000;
                recordTimer.Start();
            }
            catch (Exception ex)
            {
                lock (writerLock)
                {
                    writer?.Dispose();
                    writer = null;
                }
                MessageBox.Show(T("Kayıt başlatılamadı: ") + ex.Message, T("Kayıt hatası"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopRecordingAndSave()
        {
            if (!isRecording) return;
            isRecording = false;
            recordTimer.Stop();
            btnRecord.Text = T("10 sn Kayıt");
            btnBrowseFolder.Enabled = true;
            txtRecordingDirectory.Enabled = true;

            try
            {
                lock (writerLock)
                {
                    if (writer != null)
                    {
                        writer.Flush();
                        writer.Dispose();
                        writer = null;
                    }
                }

                if (!File.Exists(tempWavPath)) throw new FileNotFoundException(T("Geçici kayıt dosyası bulunamadı."), tempWavPath);
                File.Move(tempWavPath, finalWavPath);
                lblStatus.Text = T("Kaydedildi: ") + finalWavPath;
                tempWavPath = null;
                finalWavPath = null;
            }
            catch (Exception ex)
            {
                lblStatus.Text = T("Durum: Kayıt kaydedilemedi");
                MessageBox.Show(T("Kayıt kaydedilemedi: ") + ex.Message, T("Kayıt hatası"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            lock (audioProcessingLock)
            {
                for (int offset = 0; offset + 1 < e.BytesRecorded; offset += 2)
                {
                    short pcm = (short)(e.Buffer[offset] | (e.Buffer[offset + 1] << 8));
                    float sample = pcm / 32768f;
                    sample = bassFilter.Transform(sample);
                    sample = lowFilter.Transform(sample);
                    sample = midFilter.Transform(sample);
                    sample = highFilter.Transform(sample);
                    sample *= (float)Math.Pow(10.0, boosterDb / 20.0);
                    sample = Math.Max(-1f, Math.Min(1f, sample));
                    short output = (short)Math.Round(sample * 32767f);
                    e.Buffer[offset] = (byte)(output & 0xff);
                    e.Buffer[offset + 1] = (byte)((output >> 8) & 0xff);
                }
            }

            bufferedProvider?.AddSamples(e.Buffer, 0, e.BytesRecorded);
            lock (writerLock)
            {
                if (isRecording && writer != null) writer.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }

        private void AudioSetting_Scroll(object sender, EventArgs e)
        {
            UpdateAudioSettingLabels();
            UpdateAudioProcessingSettings();
        }

        private void AppRefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshAppSessions();
        }

        private void BtnRefreshApps_Click(object sender, EventArgs e)
        {
            RefreshAppSessions();
        }

        private void RefreshAppSessions()
        {
            uint selectedProcessId = cbApps.SelectedItem is AppAudioSession selected ? selected.ProcessId : 0;
            List<AppAudioSession> refreshedSessions = new List<AppAudioSession>();

            try
            {
                using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
                using (MMDevice outputDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia))
                {
                    AudioSessionManager manager = outputDevice.AudioSessionManager;
                    try
                    {
                        SessionCollection sessions = manager.Sessions;
                        for (int i = 0; i < sessions.Count; i++)
                        {
                            AudioSessionControl session = sessions[i];
                            bool sessionAdded = false;
                            try
                            {
                                uint processId = session.GetProcessID;
                                if (processId == 0 || !string.Equals(session.State.ToString(), "Active", StringComparison.OrdinalIgnoreCase))
                                    continue;

                                string processName;
                                try
                                {
                                    using (Process process = Process.GetProcessById((int)processId))
                                        processName = process.ProcessName;
                                }
                                catch (ArgumentException)
                                {
                                    continue;
                                }

                                refreshedSessions.Add(new AppAudioSession(session, processId, processName));
                                sessionAdded = true;
                            }
                            catch (COMException)
                            {
                                continue;
                            }
                            finally
                            {
                                if (!sessionAdded) session.Dispose();
                            }
                        }
                    }
                    finally
                    {
                        manager.Dispose();
                    }
                }
            }
            catch (COMException ex)
            {
                foreach (AppAudioSession session in refreshedSessions) session.Dispose();
                lblAppStatus.Text = T("Uygulama sesleri alınamadı: ") + ex.Message;
                return;
            }
            catch (InvalidOperationException ex)
            {
                foreach (AppAudioSession session in refreshedSessions) session.Dispose();
                lblAppStatus.Text = T("Uygulama sesleri alınamadı: ") + ex.Message;
                return;
            }
            catch (Win32Exception ex)
            {
                foreach (AppAudioSession session in refreshedSessions) session.Dispose();
                lblAppStatus.Text = T("Uygulama sesleri alınamadı: ") + ex.Message;
                return;
            }

            foreach (AppAudioSession session in appAudioSessions) session.Dispose();
            appAudioSessions.Clear();
            appAudioSessions.AddRange(refreshedSessions);

            isRefreshingAppSessions = true;
            cbApps.BeginUpdate();
            cbApps.Items.Clear();
            foreach (AppAudioSession session in appAudioSessions) cbApps.Items.Add(session);
            int selectedIndex = appAudioSessions.FindIndex(session => session.ProcessId == selectedProcessId);
            if (selectedIndex < 0 && cbApps.Items.Count > 0) selectedIndex = 0;
            cbApps.SelectedIndex = selectedIndex;
            cbApps.EndUpdate();
            isRefreshingAppSessions = false;

            if (appAudioSessions.Count == 0) lblAppStatus.Text = T("Ses üreten uygulama bulunamadı. Uygulama ses çalarken listeyi yenileyin.");
            else if (cbApps.SelectedItem == null) lblAppStatus.Text = appAudioSessions.Count + T(" aktif uygulama bulundu.");
            else UpdateSelectedAppControls();
        }

        private void CbApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isRefreshingAppSessions) UpdateSelectedAppControls();
        }

        private void UpdateSelectedAppControls()
        {
            AppAudioSession session = cbApps.SelectedItem as AppAudioSession;
            bool enabled = session != null;
            tbAppVolume.Enabled = enabled;
            chkAppMute.Enabled = enabled;
            if (!enabled) return;

            isRefreshingAppSessions = true;
            tbAppVolume.Value = Clamp((int)Math.Round(session.Volume.Volume * 100), tbAppVolume.Minimum, tbAppVolume.Maximum);
            chkAppMute.Checked = session.Volume.Mute;
            lblAppVolume.Text = tbAppVolume.Value + "%";
            lblAppStatus.Text = T("Uygulama sesi: ") + session.DisplayName;
            isRefreshingAppSessions = false;
        }

        private void TbAppVolume_Scroll(object sender, EventArgs e)
        {
            AppAudioSession session = cbApps.SelectedItem as AppAudioSession;
            if (session == null) return;
            try
            {
                session.Volume.Volume = tbAppVolume.Value / 100f;
                lblAppVolume.Text = tbAppVolume.Value + "%";
            }
            catch (COMException ex)
            {
                lblAppStatus.Text = T("Ses seviyesi değiştirilemedi: ") + ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                lblAppStatus.Text = T("Ses seviyesi değiştirilemedi: ") + ex.Message;
            }
        }

        private void ChkAppMute_CheckedChanged(object sender, EventArgs e)
        {
            if (isRefreshingAppSessions) return;
            AppAudioSession session = cbApps.SelectedItem as AppAudioSession;
            if (session == null) return;
            try
            {
                session.Volume.Mute = chkAppMute.Checked;
            }
            catch (COMException ex)
            {
                lblAppStatus.Text = T("Sessiz durumu değiştirilemedi: ") + ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                lblAppStatus.Text = T("Sessiz durumu değiştirilemedi: ") + ex.Message;
            }
        }

        private void UpdateAudioSettingLabels()
        {
            lblBassValue.Text = FormatDecibels(tbBass.Value);
            lblEqLowValue.Text = FormatDecibels(tbEqLow.Value);
            lblEqMidValue.Text = FormatDecibels(tbEqMid.Value);
            lblEqHighValue.Text = FormatDecibels(tbEqHigh.Value);
            lblBoostValue.Text = "+" + tbBoost.Value + " dB";
        }

        private static string FormatDecibels(int value)
        {
            return (value > 0 ? "+" : string.Empty) + value + " dB";
        }

        private void UpdateAudioProcessingSettings()
        {
            lock (audioProcessingLock)
            {
                boosterDb = tbBoost.Value;
                bassFilter = BiQuadFilter.LowShelf(SampleRate, 100f, 1f, tbBass.Value);
                lowFilter = BiQuadFilter.PeakingEQ(SampleRate, 250f, 0.8f, tbEqLow.Value);
                midFilter = BiQuadFilter.PeakingEQ(SampleRate, 1000f, 0.8f, tbEqMid.Value);
                highFilter = BiQuadFilter.PeakingEQ(SampleRate, 6000f, 0.8f, tbEqHigh.Value);
            }
        }

        private void BtnBrowseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = T("10 saniyelik kayıtların kaydedileceği klasörü seçin.");
                if (Directory.Exists(txtRecordingDirectory.Text)) dialog.SelectedPath = txtRecordingDirectory.Text;
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                txtRecordingDirectory.Text = dialog.SelectedPath;
                settings.RecordingDirectory = dialog.SelectedPath;
                SaveSettings();
            }
        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            string name = txtProfileName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(T("Profil için bir ad girin."), T("Profil"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AudioProfile profile = new AudioProfile
            {
                Name = name,
                Bass = tbBass.Value,
                EqLow = tbEqLow.Value,
                EqMid = tbEqMid.Value,
                EqHigh = tbEqHigh.Value,
                Booster = tbBoost.Value
            };
            int existingIndex = settings.Profiles.FindIndex(p => p != null && string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
            if (existingIndex >= 0) settings.Profiles[existingIndex] = profile;
            else settings.Profiles.Add(profile);

            isLoadingSettings = true;
            cbProfiles.Items.Clear();
            foreach (AudioProfile savedProfile in settings.Profiles) cbProfiles.Items.Add(savedProfile.Name);
            cbProfiles.SelectedItem = profile.Name;
            isLoadingSettings = false;
            if (SaveSettings()) lblStatus.Text = T("Profil kaydedildi: ") + name;
            else lblStatus.Text = T("Profil diske kaydedilemedi.");
        }

        private void BtnLoadProfile_Click(object sender, EventArgs e)
        {
            string name = cbProfiles.SelectedItem as string;
            AudioProfile profile = settings.Profiles.Find(p => p != null && string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
            if (profile == null)
            {
                MessageBox.Show(T("Yüklenecek bir profil seçin."), T("Profil"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tbBass.Value = Clamp(profile.Bass, tbBass.Minimum, tbBass.Maximum);
            tbEqLow.Value = Clamp(profile.EqLow, tbEqLow.Minimum, tbEqLow.Maximum);
            tbEqMid.Value = Clamp(profile.EqMid, tbEqMid.Minimum, tbEqMid.Maximum);
            tbEqHigh.Value = Clamp(profile.EqHigh, tbEqHigh.Minimum, tbEqHigh.Maximum);
            tbBoost.Value = Clamp(profile.Booster, tbBoost.Minimum, tbBoost.Maximum);
            UpdateAudioSettingLabels();
            UpdateAudioProcessingSettings();
            txtProfileName.Text = profile.Name;
            lblStatus.Text = T("Profil yüklendi: ") + profile.Name;
        }

        private void CbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoadingSettings && cbProfiles.SelectedItem != null)
                txtProfileName.Text = cbProfiles.SelectedItem.ToString();
        }

        private static int Clamp(int value, int minimum, int maximum)
        {
            return Math.Max(minimum, Math.Min(maximum, value));
        }

        private bool SaveSettings()
        {
            try
            {
                settings.RecordingDirectory = txtRecordingDirectory.Text.Trim();
                settings.Language = currentLanguage;
                string directory = Path.GetDirectoryName(settingsFilePath);
                Directory.CreateDirectory(directory);
                using (FileStream stream = File.Create(settingsFilePath))
                {
                    new XmlSerializer(typeof(AppSettingsData)).Serialize(stream, settings);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(T("Ayarlar kaydedilemedi: ") + ex.Message, T("Ayarlar"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static int GetSelectedDeviceIndex(string item)
        {
            if (string.IsNullOrEmpty(item)) return 0;
            string[] parts = item.Split(new[] { ':' }, 2);
            return int.TryParse(parts[0], out int index) ? index : 0;
        }

        private void CleanupAudio()
        {
            waveIn?.Dispose();
            waveIn = null;
            waveOut?.Dispose();
            waveOut = null;
            bufferedProvider = null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            appRefreshTimer.Stop();
            appRefreshTimer.Dispose();
            recordTimer.Stop();
            if (isRecording) StopRecordingAndSave();
            StopPassthrough();
            foreach (AppAudioSession session in appAudioSessions) session.Dispose();
            appAudioSessions.Clear();
        }
#else
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(UiText.Get(UiText.DetectSystemLanguage(), "Ses özelliklerini kullanmak için NAudio NuGet paketini yükleyin."), UiText.Get(UiText.DetectSystemLanguage(), "Eksik bağımlılık"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cbInput.Enabled = false;
            cbOutput.Enabled = false;
            btnPassthrough.Enabled = false;
            btnRecord.Enabled = false;
        }
#endif
    }
}
