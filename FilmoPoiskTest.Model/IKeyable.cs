﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmoPoiskTest.Model
{
	public interface IKeyable<Key>
	{
		Key Id { get; set; }
	}
}