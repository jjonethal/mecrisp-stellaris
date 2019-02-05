<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<!-- Mecrisp-Stellaris ARM CMSIS-SVD register extractor by Terry Porter "terry@tjporter.com.au" -->

<xsl:output method ="xml" encoding="UTF-8" indent="yes"></xsl:output>

<xsl:template match="/device">
<xsl:comment> <xsl:value-of select="name"/> svdcutter template.xml creator for Mecrisp-Stellaris Forth by Matthias Koch </xsl:comment>
<xsl:comment>By Terry Porter "terry@tjporter.com.au"</xsl:comment>
<xsl:comment> NOTE: Mecrisp Stellaris enables IO PORTS A-E by default, for all other peripherals Register RCC is required</xsl:comment>
<xsl:text>

</xsl:text>
<xsl:for-each select="peripherals" >

<xsl:copy>
<xsl:text></xsl:text>
<xsl:copy-of select="peripheral/name"></xsl:copy-of>
</xsl:copy>
<xsl:text>  
</xsl:text>
</xsl:for-each> 
</xsl:template>
</xsl:stylesheet>
