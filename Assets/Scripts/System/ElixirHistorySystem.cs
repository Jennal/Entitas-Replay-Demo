using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

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
            if (_context.isPause) return;

            var last = _context.elixirHistory.entries.LastOrDefault();
            if (last != null && (last.tick == _context.tick.currentTick
                                 || Mathf.Approximately(last.elixir, _context.elixir.amount)))
            {
                return;
            }

            _context.elixirHistory.entries.Add(new ElixirHistory(
                _context.tick.currentTick,
                _context.elixir.amount
            ));
        }
    }
}