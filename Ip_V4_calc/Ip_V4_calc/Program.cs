// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IP_V4 ip = new IP_V4();

byte[] addr = new byte[4];

for(int i = 0; i < 4; i++)
{
    byte value = 0;
    string s = "";
    do
    {
        Console.WriteLine("Inserisci il {0}^ byte dell'indirizzo ip", i + 1 );
        s = Convert.ToString(Console.ReadLine());
    } while (!Byte.TryParse(s, out value));
    addr[i] = value;
}

ip.SetIp_address(addr);

addr = new byte[4];
bool flag = false;
do
{
    for (int i = 0; i < 4; i++)
    {
        byte value = 0;
        string s = "";
        flag = false;
        do
        {
            Console.WriteLine("Inserisci il {0}^ byte della subnet mask", i +1);
            s = Convert.ToString(Console.ReadLine());
            flag = Byte.TryParse(s, out value);
        } while(!flag || !ip.checkSingleByte(value));
        addr[i] = value;
    }
}while(ip.checkSubnetMask(addr));

ip.SetSubnet_Mask(addr);

//ip.Set_CIDR(23);

Console.WriteLine(ip.Get_CIDR());
Console.WriteLine(String.Join(".", ip.GetSubnetMask()));
Console.WriteLine(String.Join(".", ip.GetNetwork_Address()));
Console.WriteLine(String.Join(".", ip.GetBroadcast()));
Console.WriteLine(String.Join(".", ip.Get_WildCardMask()));
Console.WriteLine(String.Join(".", ip.GetFirstHostIP()));
Console.WriteLine(String.Join(".", ip.GetLastHostIp()));