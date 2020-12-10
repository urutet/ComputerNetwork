using System;
namespace lab6
{
    public class IPResolveClass
    {
        string ipAddress;
        string IPAddress { get => ipAddress; }
        string subnetMask;
        string SubnetMask { get => subnetMask; }
        string subnetID;
        string SubnetID { get => subnetID; set => subnetID = value; }
        string hostID;
        string HostID { get => hostID; set => hostID = value; }
        string[] addressInBinary;
        public string this[int i]
        {
            get
            {
                return addressInBinary[i];
            }
        }
            
        public IPResolveClass(string ip, string mask)
        {
            ipAddress = ip;
            subnetMask = mask;

        }

        public bool CheckAddress()
        {
            try
            {
                string[] addressSplit = IPAddress.Split('.');
                if (addressSplit.Length == 4)
                {
                    foreach (string s in addressSplit)
                    {
                        if (System.Convert.ToInt32(s) <= 255 && System.Convert.ToInt32(s) >= 0)
                        {
                            continue;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("String is in incorrect format");
                return false;
            }
        }

        public bool CheckMask()
        {
            try
            {
                string[] maskSplit = SubnetMask.Split('.');
                if (maskSplit.Length == 4)
                {
                    if (maskSplit[0] == "255")
                    {
                        if (maskSplit[1] == "255")
                        {
                            if (maskSplit[2] == "255")
                            {
                                if (maskSplit[3] == "255")
                                {
                                    return true;
                                }
                                else if (maskSplit[3] == "254" || maskSplit[3] == "252" || maskSplit[3] == "248" || maskSplit[3] == "240" || maskSplit[3] == "224" || maskSplit[3] == "192" || maskSplit[3] == "128" || maskSplit[3] == "0")
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else if (maskSplit[2] == "254" || maskSplit[2] == "252" || maskSplit[2] == "248" || maskSplit[2] == "240" || maskSplit[2] == "224" || maskSplit[2] == "192" || maskSplit[2] == "128" || maskSplit[2] == "0")
                            {
                                for (int i = 3; i < maskSplit.Length; i++)
                                {
                                    if (maskSplit[i] != "0")
                                    {
                                        return false;
                                    }
                                }
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (maskSplit[1] == "254" || maskSplit[1] == "252" || maskSplit[1] == "248" || maskSplit[1] == "240" || maskSplit[1] == "224" || maskSplit[1] == "192" || maskSplit[1] == "128" || maskSplit[1] == "0")
                        {
                            for (int i = 2; i < maskSplit.Length; i++)
                            {
                                if (maskSplit[i] != "0")
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (maskSplit[0] == "254" || maskSplit[0] == "252" || maskSplit[0] == "248" || maskSplit[0] == "240" || maskSplit[0] == "224" || maskSplit[0] == "192" || maskSplit[0] == "128" || maskSplit[0] == "0")
                        {
                            for (int i = 1; i < maskSplit.Length; i++)
                            {
                                if (maskSplit[i] != "0")
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("String is in incorrect format");
                return false;
            }
        }

        public string ShowSubnetID()
        {
            try
            {
                string[] ipAddressSplit = IPAddress.Split('.');
                string[] subnetMaskSplit = SubnetMask.Split('.');

                uint[] ipAddressInt = new uint[ipAddressSplit.Length];
                uint[] subnetMaskInt = new uint[subnetMaskSplit.Length];
                uint[] subnetIDInt = new uint[ipAddressSplit.Length];

                for (int i = 0; i < ipAddressSplit.Length; i++)
                {
                    ipAddressInt[i] = Convert.ToUInt32(ipAddressSplit[i]);
                    subnetMaskInt[i] = Convert.ToUInt32(subnetMaskSplit[i]);
                }

                for (int i = 0; i < ipAddressInt.Length; i++)
                {
                    subnetIDInt[i] = ipAddressInt[i] & subnetMaskInt[i];
                }

                subnetID = $"{subnetIDInt[0]}.{subnetIDInt[1]}.{subnetIDInt[2]}.{subnetIDInt[3]}";
                return $"{subnetIDInt[0]}.{subnetIDInt[1]}.{subnetIDInt[2]}.{subnetIDInt[3]}";
            }
            catch
            {
                Console.WriteLine("String is in incorrect format");
                return "Fail";
            }
        }

        public string ShowHostID()
        {
            try
            {
                string[] ipAddressSplit = IPAddress.Split('.');
                string[] subnetMaskSplit = SubnetMask.Split('.');

                uint[] ipAddressInt = new uint[ipAddressSplit.Length];
                uint[] subnetMaskInt = new uint[subnetMaskSplit.Length];
                uint[] hostIDInt = new uint[ipAddressSplit.Length];

                for (int i = 0; i < ipAddressSplit.Length; i++)
                {
                    ipAddressInt[i] = Convert.ToUInt32(ipAddressSplit[i]);
                    subnetMaskInt[i] = Convert.ToUInt32(subnetMaskSplit[i]);
                }

                for (int i = 0; i < ipAddressInt.Length; i++)
                {
                    hostIDInt[i] = ipAddressInt[i] & ~subnetMaskInt[i];
                }

                HostID = $"{hostIDInt[0]}.{hostIDInt[1]}.{hostIDInt[2]}.{hostIDInt[3]}";
                return $"{hostIDInt[0]}.{hostIDInt[1]}.{hostIDInt[2]}.{hostIDInt[3]}";
            }
            catch
            {
                Console.WriteLine("String is in incorrect format");
                return "Fail";
            }
        }
    }
}
