const puppeteer = require('puppeteer');

const configBots = require("./config-bots.json");

//-- CONFIGURAR ESSES PARÂMETROS DE ACORDO COM A MÁQUINA QUE EXECUTARÁ OS BOT'S ------------
const userDataDir = 'C:\\Users\\andersono\\AppData\\Local\\Google\\Chrome\\User Data\\Default';
const executablePath = 'C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe'
//------------------------------------------------------------------------------------------

const height = 1000;
const width = 800;

var to = '';
var message = '';
var initialDate = `${new Date(Date.now()).getFullYear()}${new Date(Date.now()).getMonth()+1}${new Date(Date.now()).getDate()}`;

(async () => {
    console.clear();
    console.log(`${initialDate}: Iniciando processo de execução dos bots...`);
    console.log('');

    while (true) {
        console.log('Aguardando bot para execução...');

        awaitBot();

        if (to != "" && message != "") {
            const browser = await puppeteer.launch(
                { 
                    headless: true, // Exibe o navegador
                    defaultViewport: { width: width, height: height - 150 }, // Altera dimensões da página
                    userDataDir: userDataDir, // Caminho do usuário. Pra evitar de ficar configurando o web.whatsapp varias vezes
                    executablePath: executablePath, // Caminho do executável do Chrome
                    args: [
                        `--window-size=${width},${height}`, // Altera dimensões do navegador
                    ]      
                }
            );    
            
            const page = await browser.newPage();
            await page.setUserAgent(
                "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.108 Safari/537.36"
            );
    
            await page.goto("https://discord.com/channels/704737085126475776/763005091997286420");
            // MARCILIO DE TESTE await page.goto("https://discord.com/channels/@me/723143704050925588");            
            
            console.log('Fazendo os preparativos para execução do bot. Aguarde...');
            console.log('');

            try {
                // login no discord se for a primeira vez
                await page.waitForSelector('#uid_5');
                await page.type('#uid_5', 'andersono@mastermaq.com.br');
                await page.type('#uid_8', '@231981a');
                await page.keyboard.press('Enter');
                    
            } catch (error) {
                
            } finally {
                // envio da mensagem
                const selector = "#app-mount > div.appDevToolsWrapper-1QxdQf > div > div.app-3xd6d0 > div > div.layers-OrUESM.layers-1YQhyW > div > div.container-1eFtFS > div > div > div.chat-2ZfjoI > div.content-1jQy2l > main > form > div > div.scrollableContainer-15eg7h.webkit-QgSAqd > div > div.textArea-2CLwUE.textAreaSlate-9-y-k2.slateContainer-3x9zil > div > div.markup-eYLPri.editor-H2NA06.slateTextArea-27tjG0.fontSize16Padding-XoMpjI > div";
                await page.waitForSelector(selector, {timeout: 0});
                var text = await page.$(selector);
                await text.type(message);
                await page.keyboard.press('Enter');

                let hour = `${new Date(Date.now()).getHours().toString().padStart(2, '0')}:${new Date(Date.now()).getMinutes().toString().padStart(2, '0')}`;
                console.log(`${hour} Mensagem: ${message} enviada`);
                console.log('');
        
                to = '';
                message = '';
        
                await page.waitForTimeout(5000);
                await browser.close();   
            }
        }
    }
})();

function awaitBot() {  
    let hours = 0;
    let weekDay = 0;

    while (to == '') {    
        
        // Para o próximo dia os bots são reiniciados
        let dateNow = `${new Date(Date.now()).getFullYear()}${new Date(Date.now()).getMonth()+1}${new Date(Date.now()).getDate()}`;
        if (dateNow > initialDate) {
            console.log("");
            console.log("Novo dia detectado. Reiniciando bots para execução...");
            console.log("");

            configBots.forEach((configBot) => {
                configBot.execute = true;
            });

            initialDate = dateNow;
            to = '';
            message = '';

            console.log(`${initialDate}: Iniciando processo de execução dos bots...`);
            console.log('');
            break;
        }

        hours = parseInt(`${new Date(Date.now()).getHours().toString().padStart(2, '0')}${new Date(Date.now()).getMinutes().toString().padStart(2, '0')}`);
        weekDay = new Date(Date.now()).getDay();

        configBots.forEach((configBot) => {
            if (configBot.execute) {
                configBot.days.forEach((day) => {
                    if (configBot.active && weekDay === day && hours == configBot.hours) {
                        to = configBot.to;
                        message = day === 5 && configBot.message.length > 1 ? configBot.message[1] : configBot.message[0];
                        configBot.execute = false;
                        return;
                    }
                });
            }
            if (to != '') return;
        });
    }
}
