  <xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <!-- Bitfields.xsl by Terry Porter "terry@tjporter.com.au" -->
    <!-- <xsl:param name="parameters" select=" 'file:///parameters.txt' " /> -->
    <!-- <xsl:param name="file" select="document('referenced.xml')"/> -->
    <xsl:variable name="fileA" select="document('template.xml')"/>
    <xsl:output method="text"/>
    <!-- <xsl:output method="xml" encoding="UTF-8" indent="yes"/> -->
    <xsl:template match="/device">
<xsl:text>\ </xsl:text><xsl:value-of select="name"/> <xsl:text> Register Bitfield Definitions for Mecrisp-Stellaris Forth by Matthias Koch. 
</xsl:text>
<xsl:text>\ bitfield.xsl takes STM32Fxx.svd, config.xml and produces bitfield.fs
</xsl:text>
<xsl:text>\ Written by Terry Porter "terry@tjporter.com.au" 2016 - 2018 and released under the GPL V2.
</xsl:text>
<xsl:text>\ Replace 'bis!' (set bit) with 'bic!' to CLEAR bit, 'bit@' to test bit etc.
</xsl:text>
<xsl:text>
</xsl:text>
      <xsl:for-each select="peripherals/peripheral">
          <!-- <xsl:value-of select="name"></xsl:value-of> -->
        <xsl:choose>
            <xsl:when test=" name = $fileA/peripherals/name">

            <xsl:variable name="device" select="name" />
<!-- Register name and access method -->
          <xsl:for-each select="registers/register" >
<xsl:text>
</xsl:text>
            <xsl:text>\ </xsl:text>
            <xsl:value-of select="$device"/>
              <xsl:text>-</xsl:text>
            <xsl:value-of select="name" />
            <xsl:variable name="reg1" select="name"/>
            <xsl:text> (</xsl:text>
            <xsl:value-of select="access"/><xsl:text>)</xsl:text>
<!-- Register name and access method -->            

<xsl:text>
</xsl:text>
            

            <xsl:for-each select="fields/field">
              <xsl:text>: </xsl:text>
              <xsl:value-of select="$device"/>
              <xsl:text>-</xsl:text>
              <xsl:value-of select="$reg1"/>
              <xsl:text>_</xsl:text>
              <xsl:value-of select="name"/>
              <xsl:text> </xsl:text>
              
              <xsl:text> </xsl:text>
<!-- Register BitWidths -->
                <xsl:choose>
                    <xsl:when test ="bitWidth = 1">
                      <xsl:text> %1 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 2">
                      <xsl:text> ( %XX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 3">
                      <xsl:text> ( %XXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 4">
                      <xsl:text> ( %XXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 5">
                      <xsl:text> ( %XXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 6">
                      <xsl:text> ( %XXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 7">
                      <xsl:text> ( %XXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 8">
                      <xsl:text> ( %XXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 9">
                      <xsl:text> ( %XXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 12">
                      <xsl:text> ( %XXXXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 14">
                      <xsl:text> ( %XXXXXXXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 15">
                      <xsl:text> ( %XXXXXXXXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 16">
                      <xsl:text> ( %XXXXXXXXXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 20">
                      <xsl:text> ( %XXXXXXXXXXXXXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 24">
                      <xsl:text> ( %XXXXXXXXXXXXXXXXXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 28">
                      <xsl:text> ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 32">
                      <xsl:text> ( %XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX -- ) </xsl:text>
                    </xsl:when>
	    </xsl:choose>

	    <xsl:value-of select="bitOffset"/>
              <xsl:text> lshift </xsl:text>
              <xsl:value-of select="$device"/>
              <xsl:text>-</xsl:text>
	      <xsl:value-of select="$reg1"/>
	      
		  <xsl:text> bis! ; </xsl:text>
		  <xsl:text> \ </xsl:text>
		  <xsl:value-of select="$device"/>
		  <xsl:text>-</xsl:text>
		  <xsl:value-of select="$reg1"/>
		  <xsl:text>_</xsl:text>
		  <xsl:value-of select="name"/>
		  <xsl:text>    </xsl:text>
		  <xsl:value-of select="description"/>
<xsl:text>
</xsl:text>
            </xsl:for-each>
 </xsl:for-each>
            </xsl:when>
        </xsl:choose>
      </xsl:for-each>
      
    </xsl:template>
  </xsl:stylesheet>
