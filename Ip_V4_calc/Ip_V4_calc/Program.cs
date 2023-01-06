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
        Console.WriteLine("Inserisci un byte {0}", i);
        s = Convert.ToString(Console.ReadLine());
    } while (!Byte.TryParse(s, out value));
    addr[i] = value;
}

ip.Set_IPV4(addr);

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
            Console.WriteLine("Inserisci un byte {0}", i);
            s = Convert.ToString(Console.ReadLine());
            flag = Byte.TryParse(s, out value);
        } while(!flag || !ip.checkSingleByte(value));
        addr[i] = value;
    }
}while(ip.checkSubnetMask(addr));

ip.SetSubnetMask(addr);

Console.WriteLine(ip.Get_CIDR());

ip.Set_CIDR(23);

//Console.WriteLine(Convert.ToString(ip.GetSubnetMask()));