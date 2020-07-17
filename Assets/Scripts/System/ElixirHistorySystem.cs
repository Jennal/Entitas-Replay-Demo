using System.Collections.Generic;
using Entitas;

namespace System
{
    public class ElixirHistorySystem : IInitializeSystem, ICleanupSystem
    {
        readonly GameContext _context; 
        
        public ElixirHistorySystem(Contexts contexts)
        {
            _context = contexts.game;
        }
        
        public void Initialize()
        {
            _context.ReplaceElixirHistory(new List<ElixirHistory>());
        }

        public void Cleanup()
        {
            _context.elixirHistory.entries.Add(new ElixirHistory(
                _context.tick.currentTick,
                _context.elixir.amount
            ));
        }
    }
}