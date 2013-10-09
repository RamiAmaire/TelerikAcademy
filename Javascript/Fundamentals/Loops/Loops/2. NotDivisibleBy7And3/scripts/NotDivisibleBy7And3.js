var n = 50;
for (var i = 0; i < n; i++) 
{
    if (i % 7 == 0 || i % 3 == 0) 
    {
        continue;
    }
    jsConsole.write(i + " ");
}