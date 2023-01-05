// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

class IPV4
{
    private byte[] ipv4_adrr;
    private byte[] sub_mask;

    public byte[] GetIP_Addr()
    {
        return ipv4_adrr;
    }

    public byte[] GetSubnetMask()
    {
        return sub_mask;
    }

    public void Set_IPV4(byte[] ipv4_inserted)
    {
        this.ipv4_adrr = ipv4_inserted;
    }

    //2 modi
    //primo: fare and con la subnet mask
    //secondo: trovare il cidr, verificare i bit posti ad 1 fino a quando non si raggiunge il cidr
    public bool[,] GetIP_addrbool()//per ritornare il bool
    {
        bool[,] ip_v4_bool = new bool[4,8];
        return ip_v4_bool;
    }

    public byte[] GetFirstHostIP()
    {
        byte[] ip_v4_first = new byte[4];
        foreach(byte group in ipv4_adrr)
        {
            //just add one from network address if it insn't the last one
        }
        return ip_v4_first;
    }

    public byte[] GetNetworkAddress()
    {
        byte[] bytes = new byte[4];
        int i = 0;
        foreach(byte single in bytes)
        {
            //bytes[i]
        }

        return bytes;
    }

    public int Get_CIDR()
    {
        int total = 0;
        foreach(byte octate in sub_mask)
        {
            if(octate == 255) 
            { 
                total+=8; 
            }
            else if(octate== 0)
            {
                break;
            }
            else
            {
                int oct_not_full = octate;
                while(octate > 0)
                {
                    total += octate & 1;
                    oct_not_full >>= 1;
                }
            }
        }
        return total;
    }

    public void Set_CIDR(int bits)
    {
        string final_byte = "";
        for(int i = 0; i < bits / 8; i++)//conto il numero di byte
        {
            if(bits - (i * 8)% 8 == 0)
            {
                sub_mask[i] = 255;
            }
            else{
                
                for (int j =0;  j < (bits - (i * 8)); j++)
                {
                    final_byte += "1";
                }
                final_byte.PadRight(8, '0');
                sub_mask[i] = Convert.ToByte(final_byte);
            }
        }
    }

    public 
}
