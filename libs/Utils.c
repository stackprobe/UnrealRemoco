#include "all.h"

autoList_t *OLToLines(autoList_t *ol) // ol: 開放する。
{
	autoList_t *lines = newList();
	uint index;
	autoBlock_t *block;

	foreach(ol, block, index)
	{
		addElement(lines, (uint)unbindBlock2Line(block));
	}
	releaseAutoList(ol);
	return lines;
}
autoList_t *LinesToOL(autoList_t *lines) // lines: 開放する。
{
	autoList_t *ol = newList();
	uint index;
	char *line;

	foreach(lines, line, index)
	{
		addElement(ol, (uint)ab_makeBlockLine(line));
	}
	releaseDim(lines, 1);
	return ol;
}
void ReleaseOL(autoList_t *ol)
{
	releaseDim_BR(ol, 1, releaseAutoBlock);
}
void Line2AsciiKana(char *line)
{
	char *p;

	for(p = line; *p; p++)
		if(!m_isRange(*p, 0x20, 0x7e) && !m_isRange(*p, 0xa1, 0xdf))
			*p = '?';
}
