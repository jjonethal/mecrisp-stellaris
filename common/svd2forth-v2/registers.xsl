<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
 <!-- register Word generation reference file for Mecrisp-Stellaris Forth by Matthias Koch. -->

  <xsl:variable name="fileA" select="document('template.xml')"/>
  <xsl:output method="text"/>
  <xsl:template match="/device">
    <xsl:value-of select="name"/>
    <xsl:text> register Word generation reference file for Mecrisp-Stellaris Forth by Matthias Koch.
</xsl:text>
    <xsl:text>Uses registers.xsl and your config.xml file.
</xsl:text>
<xsl:text>Do not load this file, just copy and paste what you need into your source file.
</xsl:text>
    <xsl:text>Written by Terry Porter "terry@tjporter.com.au" 2016. Released under the GPL V2
</xsl:text>
    <xsl:text>
      </xsl:text>
    <xsl:text>
      </xsl:text>
    <xsl:for-each select="peripherals/peripheral">
      <!-- <xsl:value-of select="name"></xsl:value-of> -->
      <xsl:choose>
        <xsl:when test=" name = $fileA/peripherals/name">
          <xsl:variable name="device" select="name"/>
          <xsl:text>
################################### </xsl:text>
          <xsl:value-of select="$device"/>
          <xsl:text> ###################################</xsl:text>
          <xsl:for-each select="registers/register">
            <xsl:text>
</xsl:text>
            <xsl:value-of select="$device"/>
            <xsl:text>_</xsl:text>
            <xsl:value-of select="name"/>
            <xsl:variable name="reg1" select="name"/>
            <xsl:text> (</xsl:text>
            <xsl:value-of select="access"/>
            <xsl:text>)</xsl:text>
            <xsl:text>
</xsl:text>
            <xsl:value-of select="resetValue"/>
            <xsl:text> CONSTANT </xsl:text>
            <xsl:text>RESET_</xsl:text>
            <xsl:value-of select="$device"/>
            <xsl:text>_</xsl:text>
            <xsl:value-of select="name"/>
            <xsl:text> </xsl:text>
            <xsl:for-each select="fields/field">
              <xsl:text>
 %</xsl:text>
              <xsl:choose>
                <xsl:when test="bitWidth = 1">
                  <xsl:text>1 </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 2">
                  <xsl:text>xx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 3">
                  <xsl:text>xxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 4">
                  <xsl:text>xxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 5">
                  <xsl:text>xxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 6">
                  <xsl:text>xxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 7">
                  <xsl:text>xxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 8">
                  <xsl:text>xxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 9">
                  <xsl:text>xxxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 12">
                  <xsl:text>xxxxxxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 14">
                  <xsl:text>xxxxxxxxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 15">
                  <xsl:text>xxxxxxxxxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 16">
                  <xsl:text>xxxxxxxxxxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 20">
                  <xsl:text>xxxxxxxxxxxxxxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 24">
                  <xsl:text>xxxxxxxxxxxxxxxxxxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 28">
                  <xsl:text>xxxxxxxxxxxxxxxxxxxxxxxxxxxx </xsl:text>
                </xsl:when>
                <xsl:when test="bitWidth = 32">
                  <xsl:text>xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx </xsl:text>
                </xsl:when>
              </xsl:choose>
              <xsl:text> </xsl:text>
              <xsl:value-of select="bitOffset"/>
              <xsl:text> </xsl:text>
              <xsl:text>lshift</xsl:text>
              <xsl:text> </xsl:text>
              <xsl:value-of select="$device"/>
              <xsl:text>_</xsl:text>
              <xsl:value-of select="$reg1"/>
              <xsl:text> bis! </xsl:text>
              <xsl:text>       \</xsl:text>
              <xsl:text> </xsl:text>
              <xsl:value-of select="$device"/>
              <xsl:text>_</xsl:text>
              <xsl:value-of select="name"/>
              <xsl:text>	Bit </xsl:text>
              <xsl:value-of select="bitOffset"/>
              <xsl:text>	 Width </xsl:text>
              <xsl:value-of select="bitWidth"/>
              <xsl:text/>
            </xsl:for-each>
            <xsl:text>
</xsl:text>
            <xsl:text>\ </xsl:text>
            <xsl:value-of select="$device"/>
            <xsl:text>_</xsl:text>
            <xsl:value-of select="$reg1"/>
            <xsl:text> Register BitField Fetch Words  
</xsl:text>
            <xsl:for-each select="fields/field">
              <xsl:text>: </xsl:text>
              <xsl:value-of select="$device"/>
              <xsl:text>_</xsl:text>
              <xsl:value-of select="name"/>
              <xsl:text>@ </xsl:text>
              <xsl:value-of select="$device"/>
              <xsl:text>_</xsl:text>
              <xsl:value-of select="$reg1"/>
              <xsl:text> @ %</xsl:text>
                             <xsl:choose>
                    <xsl:when test ="bitWidth = 1">
                      <xsl:text>1 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 2">
                      <xsl:text>11 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 3">
                      <xsl:text>111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 4">
                      <xsl:text>1111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 5">
                      <xsl:text>11111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 6">
                      <xsl:text>111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 7">
                      <xsl:text>1111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 8">
                      <xsl:text>11111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 9">
                      <xsl:text>111111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 12">
                      <xsl:text>11111111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 14">
                      <xsl:text>11111111111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 15">
                      <xsl:text>111111111111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 16">
                      <xsl:text>1111111111111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 20">
                      <xsl:text>11111111111111111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 24">
                      <xsl:text>111111111111111111111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 28">
                      <xsl:text>1111111111111111111111111111 </xsl:text>
                    </xsl:when>
                    <xsl:when test ="bitWidth = 32">
                      <xsl:text>11111111111111111111111111111111 </xsl:text>
                    </xsl:when>	   
                </xsl:choose>
              <xsl:text> </xsl:text>
              <xsl:value-of select="bitOffset"/>
              <xsl:text> lshift and </xsl:text>
              <xsl:value-of select="bitOffset"/>
              <xsl:text> rshift ; </xsl:text>
              <xsl:text>
</xsl:text>
            </xsl:for-each>
          </xsl:for-each>
          <xsl:text>
                    </xsl:text>
        </xsl:when>
      </xsl:choose>
    </xsl:for-each>
    <xsl:text>
</xsl:text>
  </xsl:template>
</xsl:stylesheet>
