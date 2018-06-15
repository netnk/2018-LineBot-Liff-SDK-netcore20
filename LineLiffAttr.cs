using System;
using System.Collections.Generic;

public class View
{
    public string type { get; set; }
    public string url { get; set; }
}

public class View2
{
    public View view { get; set; }
}

public class LiffViewReceive
{
    public string liffId { get; set; }
}

public class App
{
    public string liffId { get; set; }
    public View view { get; set; }
}

public class GetAllLiff
{
    public List<App> apps { get; set; }
}
