<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<!-- Peripheral Lister by Terry Porter "terry@tjporter.com.au" -->
<!-- <xsl:param name="parameters" select=" 'file:///parameters.txt' " /> -->

<!-- <xsl:param name="file" select="document('referenced.xml')"/> -->
<xsl:variable name="fileA" select="document('template.xml')"/>

<xsl:output method="text"/>
<!-- <xsl:output method="xml" encoding="UTF-8" indent="yes"/> -->

<xsl:template match="/device">
<xsl:text>\ TEMPLATE FILE for </xsl:text>
<xsl:value-of select="name"/>
<xsl:text>
</xsl:text>
<xsl:text>\ created by svdcutter for Mecrisp-Stellaris Forth by Matthias Koch</xsl:text>
<xsl:text>
</xsl:text>
<xsl:text>\ sdvcutter  takes a CMSIS-SVD file plus a hand edited config.xml file as input </xsl:text>
<xsl:text>
</xsl:text>
<xsl:text>\ By Terry Porter "terry@tjporter.com.au"</xsl:text>
<xsl:text>
</xsl:text>

<xsl:text>

compiletoflash

\ pretty printing words

 : b32loop. ( u -- ) \ print 1 bit groups
 0  &lt;#
 31 0 DO 
 # 32 HOLD LOOP
 # #&gt;
 TYPE ; 

: 1b. ( u -- ) cr 
." 3|3|2|2|2|2|2|2|2|2|2|2|1|1|1|1|1|1|1|1|1|1" cr
." 1|0|9|8|7|6|5|4|3|2|1|0|9|8|7|6|5|4|3|2|1|0|9|8|7|6|5|4|3|2|1|0 " cr
@ binary b32loop. decimal cr ;


: b8loop. ( u -- )
0 &lt;#
7 0 DO
# # # #
32 HOLD
LOOP
# # # # 
#&gt;
TYPE ;

: 4b. ( u -- ) cr \ Print 4 bit groups
."  07   06   05   04   03   02   01   00  " cr
@ binary b8loop. cr ;


: b16loop. ( u -- ) 0
&lt;#
15 0 DO
# #
32 HOLD
LOOP
# #
#&gt;
TYPE ;

: 2b. ( u -- ) cr \ Print 2 bit groups
." 15|14|13|12|11|10|09|08|07|06|05|04|03|02|01|00 " cr
@ binary b16loop. cr
;


</xsl:text>

<xsl:text>
\ available forth template words as selected by config.xml
</xsl:text>
<xsl:text>
</xsl:text>

<xsl:for-each select="peripherals/peripheral">
<!-- <xsl:value-of select="name"></xsl:value-of> -->
<xsl:choose>
<xsl:when test=" name = $fileA/peripherals/name">

<xsl:variable name="device" select="name" />
<xsl:value-of select="baseAddress" /> constant <xsl:value-of select="$device" /> 
<xsl:text>
</xsl:text>

<xsl:for-each select="registers/register" >
<xsl:value-of select="$device"/>
<xsl:text> </xsl:text>
<xsl:value-of select="addressOffset" />
<xsl:text> </xsl:text>
<xsl:text>+</xsl:text>
<xsl:text> </xsl:text>
<xsl:text>constant</xsl:text>
<xsl:text> </xsl:text>
<xsl:value-of select="$device"/><xsl:text>_</xsl:text><xsl:value-of select="name" />
<xsl:text>
</xsl:text>
</xsl:for-each>
<xsl:text>: </xsl:text>
<xsl:value-of select="$device"/><xsl:text>.</xsl:text>
<xsl:text> cr</xsl:text>
<xsl:text>
</xsl:text>
<xsl:for-each select="registers/register" >
<xsl:text>." </xsl:text>
<xsl:value-of select="$device"/><xsl:text>_</xsl:text><xsl:value-of select="name" />
<xsl:text>: " </xsl:text>
<xsl:value-of select="$device"/><xsl:text>_</xsl:text><xsl:value-of select="name" />
<!--  sub-registers selected now, still trying to derive a suitable pretty print choice system based on bitwith -->
<xsl:text> 1b.</xsl:text>
<!---<xsl:if test="fields/field/bitWidth   &gt 0       "   > 1b. </xsl:if>
<xsl:if test="fields/field/bitWidth   = 5       "   > 5</xsl:if> 
<xsl:if test="fields/field/bitWidth   = 2        "   > 2 </xsl:if>
<xsl:if test="fields/field/bitWidth   = 4        "   > 4b. </xsl:if>
<xsl:if test=" fields/field/bitWidth   ='1' and  fields/field/bitWidth ='2' " >1b.</xsl:if> -->

<!-- <xsl:if test="fields/field/bitWidth % 2 = 1]">1b.</xsl:if> -->


<!-- end of sub-registers register select code -->
<xsl:text>
</xsl:text>
</xsl:for-each>
<xsl:text>;</xsl:text>
<xsl:text>

</xsl:text>
</xsl:when>
<xsl:otherwise>
<!-- <xsl:text>: </xsl:text>
<xsl:value-of select="name"></xsl:value-of>
<xsl:text> ." unused" ;</xsl:text>
<xsl:text>
</xsl:text>
<xsl:text>
</xsl:text> -->
</xsl:otherwise>
</xsl:choose>
</xsl:for-each>
<xsl:text>compiletoram</xsl:text>
</xsl:template>
</xsl:stylesheet>