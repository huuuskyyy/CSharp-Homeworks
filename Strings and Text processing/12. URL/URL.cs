//Write a program that parses an URL address given in the format:[protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements. 
using System;

class URL
{
    static void Main()
    {
        string address = "https://www.thisisanexample.com/still_example/end_of_example.php";
        int protocolEnd = address.IndexOf("//");
        string protocol = address.Substring(0, protocolEnd);
        int serverEnd = address.IndexOf("/", protocolEnd + 2);
        string server = address.Substring(protocolEnd + 2, serverEnd - protocolEnd - 2);
        string resource = address.Substring(serverEnd, address.Length - 1 - serverEnd);

        Console.WriteLine("Protocol - " + protocol);
        Console.WriteLine("Server - " + server);
        Console.WriteLine("Resource - " + resource);
    }
}
