var number = 201;
var temp = number.toString();
if (temp.length == 1) 
{
    switch (parseInt(temp)) 
    {
        case 1: jsConsole.writeLine("One"); break;
        case 2: jsConsole.writeLine("Two"); break;
        case 3: jsConsole.writeLine("Three"); break;
        case 4: jsConsole.writeLine("Four"); break;
        case 5: jsConsole.writeLine("Five"); break;
        case 6: jsConsole.writeLine("Six"); break;
        case 7: jsConsole.writeLine("Seven"); break;
        case 8: jsConsole.writeLine("Eight"); break;
        case 9: jsConsole.writeLine("Nine"); break;
        default:
    }
}
if (temp.length == 2) 
{
    if (parseInt(temp[0]) != 1) 
    {
        switch (parseInt(temp[0])) 
        {
            case 2: jsConsole.write("Twenty "); break;
            case 3: jsConsole.write("Thirty "); break;
            case 4: jsConsole.write("Fourty "); break;
            case 5: jsConsole.write("Fifty "); break;
            case 6: jsConsole.write("Sixty "); break;
            case 7: jsConsole.write("Seventy "); break;
            case 8: jsConsole.write("Eighty "); break;
            case 9: jsConsole.write("Ninety "); break;
            default:
        }
        switch (parseInt(temp[1])) 
        {
            case 1: jsConsole.writeLine("One"); break;
            case 2: jsConsole.writeLine("Two"); break;
            case 3: jsConsole.writeLine("Three"); break;
            case 4: jsConsole.writeLine("Four"); break;
            case 5: jsConsole.writeLine("Five"); break;
            case 6: jsConsole.writeLine("Six"); break;
            case 7: jsConsole.writeLine("Seven"); break;
            case 8: jsConsole.writeLine("Eight"); break;
            case 9: jsConsole.writeLine("Nine"); break;
            default:
        }
    }
    else 
    {
        switch (parseInt(temp[1])) 
        {
            case 0: jsConsole.writeLine("Ten"); break;
            case 1: jsConsole.writeLine("Eleven"); break;
            case 2: jsConsole.writeLine("Twelve"); break;
            case 3: jsConsole.writeLine("Thirteen"); break;
            case 4: jsConsole.writeLine("Fourteen"); break;
            case 5: jsConsole.writeLine("Fifteen"); break;
            case 6: jsConsole.writeLine("Sixteen"); break;
            case 7: jsConsole.writeLine("Seventeen"); break;
            case 8: jsConsole.writeLine("Eighteen"); break;
            case 9: jsConsole.writeLine("Nineteen"); break;
            default:
        }
    }
}
if (temp.length == 3) 
{
    switch (parseInt(temp[0])) 
    {
        case 1: jsConsole.write("One hundred "); break;
        case 2: jsConsole.write("Two hundred "); break;
        case 3: jsConsole.write("Three hundred "); break;
        case 4: jsConsole.write("Four hundred "); break;
        case 5: jsConsole.write("Five hundred "); break;
        case 6: jsConsole.write("Six hundred "); break;
        case 7: jsConsole.write("Seven hundred "); break;
        case 8: jsConsole.write("Eight hundred "); break;
        case 9: jsConsole.write("Nine hundred "); break;
        default:
    }
    if (parseInt(temp[1]) == 0) 
    {
        switch (parseInt(temp[2])) 
        {
            case 1: jsConsole.writeLine("and one"); break;
            case 2: jsConsole.writeLine("and two"); break;
            case 3: jsConsole.writeLine("and three"); break;
            case 4: jsConsole.writeLine("and four"); break;
            case 5: jsConsole.writeLine("and five"); break;
            case 6: jsConsole.writeLine("and six"); break;
            case 7: jsConsole.writeLine("and seven"); break;
            case 8: jsConsole.writeLine("and eight"); break;
            case 9: jsConsole.writeLine("and nine"); break;
            default:
        }
    }
    if (parseInt(temp[1]) == 1) 
    {
        switch (parseInt(temp[2])) 
        {
            case 0: jsConsole.writeLine("and ten"); break;
            case 1: jsConsole.writeLine("and eleven"); break;
            case 2: jsConsole.writeLine("and twelve"); break;
            case 3: jsConsole.writeLine("and thirteen"); break;
            case 4: jsConsole.writeLine("and fourteen"); break;
            case 5: jsConsole.writeLine("and fifteen"); break;
            case 6: jsConsole.writeLine("and sixteen"); break;
            case 7: jsConsole.writeLine("and seventeen"); break;
            case 8: jsConsole.writeLine("and eighteen"); break;
            case 9: jsConsole.writeLine("and nineteen"); break;
            default:
        }
    }
    if (parseInt(temp[1]) != 0 && parseInt(temp[1]) != 1) 
    {
        switch (parseInt(temp[1])) 
        {
            case 2: jsConsole.write("and twenty "); break;
            case 3: jsConsole.write("and thirty "); break;
            case 4: jsConsole.write("and fourty "); break;
            case 5: jsConsole.write("and fifty "); break;
            case 6: jsConsole.write("and sixty "); break;
            case 7: jsConsole.write("and seventy "); break;
            case 8: jsConsole.write("and eighty "); break;
            case 9: jsConsole.write("and ninety "); break;
            default:
        }
        switch (parseInt(temp[2])) 
        {
            case 1: jsConsole.writeLine("one"); break;
            case 2: jsConsole.writeLine("two"); break;
            case 3: jsConsole.writeLine("three"); break;
            case 4: jsConsole.writeLine("four"); break;
            case 5: jsConsole.writeLine("five"); break;
            case 6: jsConsole.writeLine("six"); break;
            case 7: jsConsole.writeLine("seven"); break;
            case 8: jsConsole.writeLine("eight"); break;
            case 9: jsConsole.writeLine("nine"); break;
            default:
        }
    }
}
