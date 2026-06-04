
MiDelegate f = delegate(int i, string s)
{
    return i + 100;
};

int resultado = f(250, "Jose Diaz");

public delegate int MiDelegate(int i, string s);