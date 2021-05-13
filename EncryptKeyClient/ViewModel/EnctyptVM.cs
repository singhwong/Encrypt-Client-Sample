using System;
using System.Threading.Tasks;
using System.Windows.Input;
using EncryptKeyClient.EncryptHelper;
using EncryptKeyClient.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EncryptKeyClient.ViewModel
{
    public class EnctyptVM:BindableBase
    {
        IEncryptService _encryptService;
        GetRandomStr rdStr;
        public EnctyptVM(IEncryptService encryptService)
        {
            _encryptService = encryptService;
            RandomSecretCommand = new Command(()=>
            {
                rdStr = new GetRandomStr();
                SecretText = rdStr.GetRandoms();
            });
            EncryptCommand = new Command(async()=>
            {
                if (await SetKeyTextInputErrorToast())
                    return;
                ResultText = _encryptService.Encrypt(KeyText,SecretText);
            });
            DecryptCommand = new Command(async()=>
            {
                if (await SetKeyTextInputErrorToast())
                    return;
                try
                {
                    ResultText = _encryptService.Decrypt(KeyText, SecretText);

                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("错误！", ex.Message, "OK");
                }
            });
            ToClipboardCommand = new Command(async()=>
            {
                if (string.IsNullOrEmpty(ResultText))
                {
                    return;
                }
                await Clipboard.SetTextAsync(ResultText);
            });
            async Task<bool> SetKeyTextInputErrorToast()
            {
                if (string.IsNullOrEmpty(SecretText)||SecretText.Length != 4)
                {
                    await App.Current.MainPage.DisplayAlert("提醒", "特定字符不能为空且长度必须为4！", "好的");
                    return true;
                }
                if (string.IsNullOrEmpty(KeyText))
                {
                    await App.Current.MainPage.DisplayAlert("提醒", "待加密内容不能为空！", "好的");
                    return true;
                }
                return false;
            }
        }
        string _secretText;
        // 4位特定字符
        public string SecretText
        {
            get => _secretText;
            set => Set(ref _secretText,value);
        }
        string _keyText;
        // 待加密的字符串
        public string KeyText
        {
            get => _keyText;
            set => Set(ref _keyText,value);
        }
        string _resultText;
        public string ResultText
        {
            get => _resultText;
            set => Set(ref _resultText,value);
        }
        public ICommand RandomSecretCommand { get; private set; }
        public ICommand EncryptCommand { get; private set; }
        public ICommand DecryptCommand { get; private set; }
        public ICommand ToClipboardCommand { get; private set; }
    }
}
