using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTestApp5
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnRequest_Clicked(object sender, EventArgs e)
        {
            string target_url = "http://saeyan2019.cafe24.com/rw.php";
            //CrossConnectivity 네트워크 연결상태 여부 체크 nuget 패키지
            if (CrossConnectivity.Current.IsConnected)
            {
                var client = new System.Net.Http.HttpClient();

                if (!string.IsNullOrEmpty(entryRequestString.Text))
                {
                    target_url += "?word=" + entryRequestString.Text;
                    //서버에 접속 및 데이터 요청
                    var response = await client.GetAsync(target_url);

                    //Response 데이터 가져오기
                    string response_word = await response.Content.ReadAsStringAsync();

                    if (response_word != "")
                    {
                        labelResponse.Text = response_word;
                    }
                    else
                    {
                        //xamarin에서 사용하는 alert 창
                        await DisplayAlert("Warning", "빈 데이터입니다.","예");
                    }
                }
                else
                {
                    await DisplayAlert("Warning", "보낼 메시지 입력바람.", "예");
                }
            }
            else
            {
                await DisplayAlert("Warning", "서버에 연결할 수 없음.", "예");
            }
        }
    }
}
