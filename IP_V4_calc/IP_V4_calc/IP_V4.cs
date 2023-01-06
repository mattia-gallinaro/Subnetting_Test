using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class IP_V4
{
    protected byte[] ipv4_adrr;
    protected byte[] sub_mask;

    public IP_V4()
    {
        ipv4_adrr = new byte[4];
        sub_mask = new byte[4];
    }

    public byte[] GetIP_Addr()
    {
        return ipv4_adrr;
    }

    public byte[] GetSubnetMask()
    {
        return sub_mask;
    }

    public void SetSubnet_Mask(byte[] sm)
    {
        this.sub_mask = sm;
    }
    public void SetIp_address(byte[] ipv4_inserted)
    {
        this.ipv4_adrr = ipv4_inserted;
    }

    public bool checkSingleByte(byte single)
    {
        byte[] bytes = new byte[]{255 , 254, 252, 248, 240, 224, 192, 128, 0};
        return Array.Exists(bytes, element => element == single);//controllo che il byte inserito corrisponda ad uno di quelli
                                                                 //assegnabili e ritorno un valore bool
    }
    public bool checkSubnetMask(byte[] sm)
    {
        bool check = false;

        for (int i = 0;  i < 3; i++)
        {
            if ((sm[i+1] != 0 && sm[i] != 255))/*effettua il contro a coppie, 
                                                * se il primo byte che controlla è diverso da 255 e il secondo byte non è zero
                                                * allora non accetta la subnet_mask
                                                */
            {
                check = true;
                break;
            }
        }
        return check;
    }

    public bool[,] GetIP_addrbool()//finire
    {
        bool[,] ip_v4_bool = new bool[4, 8];
        return ip_v4_bool;
    }

    public byte[] GetFirstHostIP()
    {
        byte[] ip_v4_first = new byte[4];
        ip_v4_first = this.GetNetwork_Address();
        ip_v4_first[3] += 1;
        return ip_v4_first;
    }

    public byte[] GetNetwork_Address()
    {
        byte[] bytes = new byte[4];
        for(int i = 0; i < 4; i++)
        {
            bytes[i] = (byte)(ipv4_adrr[i] & sub_mask[i]); 
        }

        return bytes;
    }

    public byte[] GetBroadcast()
    {
        byte[] broadcast_addr = new byte[4];
        byte[] network_addr= this.GetNetwork_Address();
        byte[] wildcard= this.Get_WildCardMask();
        for (int i = 0; i < 4; i++)
        {
            broadcast_addr[i] = (byte)(network_addr[i] | wildcard[i]);
        }
        return broadcast_addr;
    }
    public byte[] GetLastHostIp()
    {
        byte[] bytes = new byte[4];
        bytes = this.GetBroadcast();
        bytes[3] -= 1;
        return bytes;
    }
    public byte[] Get_WildCardMask()
    {
        byte[] wild_card = new byte[4];

        for(int i = 0;  i < 4; i++)
        {
            wild_card[i] = (byte)(255 - (int)sub_mask[i]);
        }
        return wild_card;
    }
    public double GetTotalNumberHost()
    {
        return Math.Pow(2, (32 - this.Get_CIDR())) -2;
    }
    /*public byte[,] GetNumberUsableHost() finire
    {
        byte[,] addresses = new byte[2,4];
        addresses[0] = this.GetFirstHostIP();
        addresses[1] = this.GetLast();
        return addresses;
    }*/
    public int Get_CIDR()
    {
        int total = 0;
        foreach (byte octate in sub_mask)
        {
            if (octate == 255)
            {
                total += 8;
            }
            else if (octate == 0)
            {
                break;
            }
            else
            {
                int oct_not_full = octate;
                while (oct_not_full > 0)
                {
                    total += oct_not_full & 1;
                    oct_not_full >>= 1;
                }
            }
        }
        return total;
    }

    public void Set_CIDR(int bits)
    {
        double sig_byte = 0;
        for (int i = 0; i < 4; i++)//conto il numero di byte
        {
            if ((bits - (i * 8)) > 8)
            {
                sub_mask[i] |= 255;
            }
            else if (bits - (i * 8) > 0)
            {
                
                for (int j = 7; j >= 8- (bits - (i * 8)); j--)
                {
                    sig_byte += Math.Pow(2, j);
                }
                sub_mask[i] = Convert.ToByte(sig_byte);
                Console.WriteLine(sub_mask[i]);
            }
            else
            {
                sub_mask[i] |= 0;
            }
        }
    }
}
