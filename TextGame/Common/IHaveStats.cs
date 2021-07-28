using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGame.Common
{
	public interface IHaveStats
	{
		double GetStat(StatKind statKind);
	}
}
