using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotWhatsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://web.whatsapp.com";

            List<string> contacts = new List<string>()
            {
    
                "Anotações", "João P." //nomes dos contatos 

            };


            ChromeDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            Thread.Sleep(5000);

            foreach (var contact in contacts)
            {
                //pesquisar o nome do grupo na barra de pesquisa do whatsapp web
                //<div class="_3FRCZ copyable-text selectable-text" contenteditable="true" data-tab="3" dir="ltr"></div>

                

                var searchBar = driver.FindElementByClassName("_3FRCZ");
                searchBar.SendKeys(contact);


                Thread.Sleep(1000);

                ////selecionar o contato 
                ////<span dir="auto" title="anotações" class="_3ko75 _5h6y_ _3whw5"><span class="matched-text _3whw5">ano</span>tações</span>

                var namecontact = driver.FindElementByXPath($"//span[@title='{contact}']");
                namecontact.Click();

                Thread.Sleep(1000);

                //Pegar o input (caixa de texto) do Whatsapp
                //<div tabindex="-1" class="_3uMse"><div tabindex="-1" class="_2FVVk _2UL8j"><div class="_2FbwG" style="visibility: visible;">Digite uma mensagem</div><div class="_3FRCZ copyable-text selectable-text" contenteditable="true" data-tab="1" dir="ltr" spellcheck="true"></div></div></div>

                var chat = driver.FindElementByClassName("_3uMse");
                chat.SendKeys("Olá tudo bem?! bot created by: João Pedro");

                Thread.Sleep(1000);

                //ativa o botão de enviar mensagem do WhatsApp
                //<span data-testid="send" data-icon="send" class=""><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="24" height="24"><path fill="currentColor" d="M1.101 21.757L23.8 12.028 1.101 2.3l.011 7.912 13.623 1.816-13.623 1.817-.011 7.912z"></path></svg></span>

                var buttonSend = driver.FindElementByXPath($"//span[@data-icon='send']");
                buttonSend.Click();
                
                
                Thread.Sleep(5000);

            }

        }
    }
}
