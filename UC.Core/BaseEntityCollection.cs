using System;
using System.Collections.Generic;
using System.Text;

namespace UC.Core
{
    /// <summary>
    /// ������� ����� ��� ��������� ���������
    /// </summary>
    public class BaseEntityCollection<T> : List<T> where T : BaseEntity
    {
    }
}
