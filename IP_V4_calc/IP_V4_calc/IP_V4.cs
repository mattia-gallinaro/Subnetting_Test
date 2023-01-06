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

    public void SetSubnetMask(byte[] sm)
    {
        this.sub_mask = sm;
    }
    public void Set_IPV4(byte[] ipv4_inserted)
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


    //2 modi
    //primo: fare and con la subnet mask
    //secondo: trovare il cidr, verificare i bit posti ad 1 fino a quando non si raggiunge il cidr
    public bool[,] GetIP_addrbool()//per ritornare il bool
    {
        bool[,] ip_v4_bool = new bool[4, 8];
        return ip_v4_bool;
    }

    public byte[] GetFirstHostIP()
    {
        byte[] ip_v4_first = new byte[4];
        foreach (byte group in ipv4_adrr)
        {
            //just add one from network address if it insn't the last one
        }
        return ip_v4_first;
    }

    public byte[] GetNetworkAddress()
    {
        byte[] bytes = new byte[4];
        int i = 0;
        foreach (byte single in bytes)
        {
            //bytes[i]
        }

        return bytes;
    }

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
        string final_byte = "";
        for (int i = 0; i < bits / 8; i++)//conto il numero di byte
        {
            if ((bits - (i * 8)) > 8)
            {
                sub_mask[i] = 255;
                Console.WriteLine("entered");
            }
            else
            {

                for (int j = 0; j < (bits - (i * 8)); j++)
                {
                    final_byte += "1";
                }
                final_byte.PadRight(8, '0');
                Console.WriteLine(final_byte);
                sub_mask[i] = Convert.ToByte(final_byte);
            }
        }
    }
}
