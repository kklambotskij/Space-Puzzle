public class RU : Localization
{
    public override string FillTheBoard()
    {
        return "������� ���� ��������";
    }

    public override string[] Greats()
    {
        return new string[] { "�������!", "�������!", "�������!", "������ ������!", "�� ����!", "����������!" };
    }

    public override string TapTileToRotate()
    {
        return "����� ����� ���������";
    }

    public override string UseHint()
    {
        return "��������� ���������";
    }
}
