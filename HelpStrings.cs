using OOP_Concepts.Dorm;
using OOP_Concepts.RecursiveList;
using System;

namespace OOP_Concepts
{
    partial class ConsoleInterface
    {
        private const String GENERAL_HELP = 
            "\n"+
            "file  - create, run or delete files with cmds, to get more info print: file --help\n"+
            "list  - operated with recurion list, to get more info print: list --help\n"+
            "dorm  - operated with dormitory, to get more info print: dorm --help\n" +
            "game  - run MinedOut game, to get more info print: game --help\n"+//
            "\n" +
            "#     - comment, put space after it\n" +
            "echo  - print everything that contains after this coommand\n" +
            "clear - clear console\n"+
            "help  - get this help\n"+
            "exit  - exit from console\n"+
            "\n";
        private const String GAME_HELP =
            "\n"+
            //"-c    --create    create custom map\n"+
            //"-l    --load      load previus map\n"+
            "-n    --new       create and load new game\n"+
            "-r    --rating    print rating\n"+
            "-g    --graphic   run windows form application with graphi UI\n"+
            "-h    --help      get help\n"+
            "\n";
        private const String FILE_HELP = 
            "\n"+
            "-c    --create    create new file enter name of the file plus .txt as parametr\n"+
            "      --delete    delete file with this name\n"+
            "-r    --run       run this file or you can just simply type name of this file without .txt\n"+
            "-h    --help      get help\n"+
            "\n";
        private const String LIST_HELP = 
            "\n"+
            "-c    --create         create new list, add items as parametrs after\n"+
            "-e    --toEnd          add new items to the end\n"+
            "-s    --toStart        add new items to the start\n"+
            "-l    --length         print length of list, and set new length send as parametr\n" +
            "      --swap           swap to elements, args is two indexes of elements\n" +
            "      --sort           sorting elements in list\n" +     
            "\n"+
            "      --clear          delete all elements\n"+
            "-p    --print          print all elements\n"+
            "-b    --addBefore      add one element before another\n"+
            "      --deleteOne      delete first element in list with this value\n"+
            "      --deleteAll      delete all elements in list with this value\n"+
            "\n"+
            "      --deleteEven    delete even elemens in list\n"+
            "      --signedAverage  print average of all elements under zerro\n"+
            "      --printOdd       print all odd elements\n"+
            "      --get            get and print elements\n"+
            "-h    --help           get help\n"+
            "\n";
        private const String DORM_HELP = 
            "\n"+
            "-f    --find       print room number, where lives this student\n"+
            "      --free       print all free rooms\n"+
            "-o    --occupancy  print occupancy of all rooms in percent\n"+
            "-p    --print      print all rooms\n"+
            "-h    --help       get help\n"+
            "\n";
    }
}