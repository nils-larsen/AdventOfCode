using System.Collections.Generic;
using System.Linq;
using System;

namespace AdventOfCode.Day25
{
    public class Turing
    {
        readonly List<int> _states;
        State CurrentState;
        public int Cursor { get; private set; }

        public Turing()
        {
            _states = Enumerable.Range(0, 100000).Select(i => 0).ToList();
            CurrentState = State.A;
            Cursor = _states.Count / 2;
        }

        public enum State
        {
            A,
            B,
            C,
            D,
            E,
            F
        }

        void ChangeState(int write, int increase, State newState)
        {
            _states[Cursor] = write;
            Cursor += increase;
            CurrentState = newState;
        }

        public int Solve(long repetitions)
        {
            for (var i = 0; i < repetitions; i++)
            {
                switch (CurrentState)
                {
                    case State.A:
                        if (_states[Cursor] == 0)
                            ChangeState(1, 1, State.B);
                        else
                            ChangeState(0, 1, State.F);
                        break;
                    case State.B:
                        if (_states[Cursor] == 0)
                            ChangeState(0, -1, State.B);
                        else
                            ChangeState(1, -1, State.C);
                        break;
                    case State.C:
                        if (_states[Cursor] == 0)
                            ChangeState(1, -1, State.D);
                        else
                            ChangeState(0, 1, State.C);
                        break;
                    case State.D:
                        if (_states[Cursor] == 0)
                            ChangeState(1, -1, State.E);
                        else
                            ChangeState(1, 1, State.A);
                        break;
                    case State.E:
                        if (_states[Cursor] == 0)
                            ChangeState(1, -1, State.F);
                        else
                            ChangeState(0, -1, State.D);
                        break;
                    case State.F:
                        if (_states[Cursor] == 0)
                            ChangeState(1, 1, State.A);
                        else
                            ChangeState(0, -1, State.E);
                        break;
                }
            }
            return _states.Sum();
        }
    }
}
