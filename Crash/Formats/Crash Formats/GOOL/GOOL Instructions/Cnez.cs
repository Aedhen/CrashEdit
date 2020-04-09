﻿namespace Crash.GOOLIns
{
    [GOOLInstruction(54,GameVersion.Crash2)]
    [GOOLInstruction(54,GameVersion.Crash3)]
    public sealed class Cnez : GOOLInstruction
    {
        public Cnez(int value,GOOLEntry gool) : base(value,gool) { }

        public override string Name => "CNEZ";
        public override string Format => "SSSSSSSSSSSSSS (RRRRRR) 10 10";
        public override string Comment => $"if {(ObjectFields)Args['R'].Value} is true, change to state {GetArg('S')}";
    }
}
