﻿namespace Crash.GOOLIns
{
    [GOOLInstruction(143,GameVersion.Crash1)]
    [GOOLInstruction(143,GameVersion.Crash1Beta1995)]
    [GOOLInstruction(143,GameVersion.Crash1BetaMAR08)]
    [GOOLInstruction(143,GameVersion.Crash1BetaMAY11)]
    [GOOLInstruction(68,GameVersion.Crash2)]
    [GOOLInstruction(68,GameVersion.Crash3)]
    public sealed class Evnc : GOOLInstruction
    {
        public Evnc(int value,GOOLEntry gool) : base(value,gool) { }

        public override string Name => "EVNC";
        public override string Format => "[EEEEEEEEEEEE] (RRRRRR) AAA (LLL)";
        public override string Comment => $"cascade event {GetArg('E')} to {GetArg('L')}" + (Args['A'].Value > 0 ? $" with {GetArg('A')} arguments (starting at {GetArg('R')})" : "");
    }
}
