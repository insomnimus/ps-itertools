---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Switch-Pipe

## SYNOPSIS
Alternates between the pipe and a collection.

## SYNTAX

```
Switch-Pipe [-ValuesRight] <System.Collections.Generic.List`1[System.Object]> [-Left <Int32>] [-Right <Int32>]
 [-DiscardRest] [-Input] <Object> [<CommonParameters>]
```

## DESCRIPTION
Alternates between the current pipe and a provided collection.
By default, items will be taken from each side 1 by 1.
First item taken is always from the pipe.
The `-Left` and `-Right` parameters specify how many items to take from the respective sources in each alternation.
If the `-DiscardRest` flag is set, no value will be produced after an alternation produces incomplete values
(e.g a source runs out of items/ it doesn't have enough items to produce).

## EXAMPLES

### Example 1
This example demonstrates a simple usage of this cmdlet.

```powershell
PS C:\> $left = "left 1", "left 2", "left 3"
PS C:\> $right = "right 1", "right2", "right3", "right4", "right5"
PS C:\> $left | Switch-Pipe $right -Right 2 -DiscardRest
```

```
left 1
right 1
right2
left 2
right3
right4
```

## PARAMETERS

### -DiscardRest
Discard leftover items if left or right are drained before the other.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Input
Any object from the pipeline.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Left
How many items to take from the left pipe in each alternation.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Right
How many items to take from the right collection in each alternation.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValuesRight
A collection to alternate with.

```yaml
Type: System.Collections.Generic.List`1[System.Object]
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Object

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
