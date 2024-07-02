using Spectre.Console;

namespace ContactList
{
    class Program
    {
        private static List<Contact> contacts = new List<Contact>();
        private static readonly string[] message = new string[4] { "The contact was saved successfully.", "The contact was successfully updated.", "The contact was successfully deleted.", "The option indicates is not correct." };


        public static void Main(string[] args) {

            Menu();

        }


        private static void Menu() {
            int index = 3;
            while (true) {
                Console.Clear();
                ListContact();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("1 - Add  2 - Update  3 - Delete  0 - Exit");
                string option = Console.ReadKey().KeyChar.ToString();
                switch (option) {
                    case "0":
                        System.Environment.Exit(1);
                        break;
                    case "1":
                        index = AddContact();
                        break;
                    case "2":
                        index = UpdateContact();
                        break;
                    case "3":
                        index = DeleteContact();
                        break;
                }

                switch (index)
                {
                    case 0:
                        Message(index);
                        break;
                    case 1:
                        Message(index);
                        break;
                    case 2: 
                        Message(index);
                        break;
                    case 3:
                        Message(index);
                        break;
                    default:
                        continue;
                }
            }
        }
        private static void Message(int index)
        {
            Console.Clear();
            Console.ForegroundColor = index != 3 ? ConsoleColor.DarkGreen : ConsoleColor.Red;
            Console.WriteLine(message[index]);
            System.Threading.Thread.Sleep(2000);
            Console.ResetColor();

        }
        private static void ListContact()
        {

            string[] header = new string[] { "#", "Full Name", "Mobile", "Email", "Note" };
            Table table = new Table();
            table.Title("Contacts");
            table.Border(TableBorder.Rounded);
            table.AddColumns(header);

            int counter = 0;
            foreach (var contact in contacts)
            {
                table.AddRow($"{counter}", $"{contact.Fullname}", $"{contact.Mobile}", $"{contact.Email}", $"{contact.Note}");
                counter++;
            }
            AnsiConsole.Write(table);
        }

        private static int AddContact()
        {
            Console.Clear ();
            Console.WriteLine("Add you contact:");
            Console.WriteLine();
            Console.WriteLine("Full name:");
            string? fullname = Console.ReadLine();
            Console.WriteLine("Mobile:");
            string? mobile = Console.ReadLine();
            Console.WriteLine("Email:");
            string? email = Console.ReadLine();
            Console.WriteLine("Note:");
            string? note = Console.ReadLine();

            if (fullname is { } && mobile is { } && email is { } && note is { })
            {
                contacts.Add(new Contact(fullname, mobile, email, note));

            }

            return 0;


        }
        private static int UpdateContact()
        {
            Console.Clear();
            Console.WriteLine("Actualizar contacto:");
            Console.WriteLine();
            Console.WriteLine("Identificador de contacto a Actualizar");
            string? id = Console.ReadLine();
            Console.WriteLine("Full name:");
            string? fullname = Console.ReadLine();
            Console.WriteLine("Mobile:");
            string? mobile = Console.ReadLine();
            Console.WriteLine("Email:");
            string? email = Console.ReadLine();
            Console.WriteLine("Note:");
            string? note = Console.ReadLine();

            try
            {

                if (id is { } && fullname is { } && mobile is { } && email is { } && note is { })
                {
                    if(contacts.Count() == 0 || contacts.Count() < Convert.ToInt32(id))
                    {
                        return 3;
                    }
                    contacts[Convert.ToInt32(id)].Fullname = fullname;
                    contacts[Convert.ToInt32(id)].Mobile = mobile;
                    contacts[Convert.ToInt32(id)].Email = email;
                    contacts[Convert.ToInt32(id)].Note = note;

                }
            }
            catch (Exception e)
            {
                return 3;
            }

            return 1;
        }
        private static int DeleteContact()
        {
            Console.Clear();
            Console.WriteLine("Actualizar contacto:");
            Console.WriteLine();
            Console.WriteLine("Identificador de contacto a Eliminar");
            string? id = Console.ReadLine();
            Console.WriteLine(contacts.Count());

            try
            {
                if (id is { })
                {
                    if (contacts.Count() == 0 || contacts.Count() < Convert.ToInt32(id))
                    {
                        return 3;
                    }
                    contacts.RemoveAt(Convert.ToInt32(id));
                }

            }
            catch (Exception e) {
                return 3;
            }

            return 2;

        }
    }
}