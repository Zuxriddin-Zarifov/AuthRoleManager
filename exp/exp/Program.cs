
    Console.WriteLine(DateTime.Now);

    var time = DateTime.UtcNow.AddMinutes(3);
    var time1 = DateTime.UtcNow;

    Console.WriteLine("time 1" + time);
    Console.WriteLine("time 2" + time1);

    if (time > time1)
        Console.WriteLine("1");
    else
        Console.WriteLine("2 ");
