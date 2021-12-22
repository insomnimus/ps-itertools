---
external help file: Itertools.dll-Help.xml
Module Name: Itertools
online version:
schema: 2.0.0
---

# Skip-Item

## SYNOPSIS
Skips items from the pipeline.

## SYNTAX

### number (Default)
```
Skip-Item -InputObject <Object> [-N] <Int32> [-Last] [<CommonParameters>]
```

### script
```
Skip-Item -InputObject <Object> [-While] <ScriptBlock> [<CommonParameters>]
```

## DESCRIPTION
Skips items from the pipeline.

## EXAMPLES

### Example 1
```powershell
1..10 | Skip-Item 5
6
7
8
9
10

1..10 | Skip-Item { $_ -ne 8 }
8
9
10
```

The first example skips first 5 items from the pipeline.
The second example skips items from the pipeline while the script block evaluates to $true.

## PARAMETERS

### -InputObject
The input object.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Last
Skip last N items instead.

```yaml
Type: SwitchParameter
Parameter Sets: number
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -N
How many items to skip.

```yaml
Type: Int32
Parameter Sets: number
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -While
Skip items while this script block evaluates to true.

```yaml
Type: ScriptBlock
Parameter Sets: script
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
