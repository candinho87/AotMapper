using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAotMapper.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class PropertyMapName(string name) : Attribute
{
    public string Name { get; } = name;
}
