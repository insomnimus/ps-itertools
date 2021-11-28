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
Skip-Item [-N] <Int32> [-Last] -Input <Object> [<CommonParameters>]
```

### script
```
Skip-Item [-While] <ScriptBlock> -Input <Object> [<CommonParameters>]
```

## DESCRIPTION
Skips items from the pipeline.

## EXAMPLES

### Example 1
This example skips numbers until it encounters a 2 digit number.

```powershell
PS C:\> 1..20 | Skip-Item { "$_".length -ne 2 }
```

```
10
11
12
13
14
15
16
17
18
19
20
```

## PARAMETERS

### -Input
The input from the pipeline.

```yaml
Type: Object
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
