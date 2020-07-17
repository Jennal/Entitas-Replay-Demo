using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[Game,Unique]
public class ElixirHistoryComponent:IComponent
{
    public List<ElixirHistory> entries;
}

public class ElixirHistory
{
    public long tick
    {
        get;
    }
    public float elixir
    {
        get;
    }
    public ElixirHistory(long tick, float amount)
    {
        this.tick = tick;
        this.elixir = amount;
    }
}

