
				<panel pos="-27,90" width="400" height="228" visible="{#itemicon == 'ammoGasCan'}" disableautobackground="true" controller="NewsWindow" cursor_area="true" browse_sound="Sounds/Crafting/craft_click_recipe" show_tfp="false" additional_sources="https://raw.githubusercontent.com/JustAlter/Mods/main/Gas Can.xml">
					<button name="btnYounger" depth="10" pos="40,-240" width="30" height="44" style="press, hover" sprite="ui_game_symbol_arrow_menu" pivot="center" sound="[paging_click]" enabled="{has_younger}" disabledcolor="[mediumGrey]"/>
					<button name="btnOlder" depth="10" pos="460,-240" width="30" height="44" style="press, hover" sprite="ui_game_symbol_arrow_menu" pivot="center" flip="horizontally" sound="[paging_click]" enabled="{has_older}" disabledcolor="[mediumGrey]"/>
					<label depth="10" name="contentText"  pos="56,-100" width="390" height="268" spacing_y="2" font_size="26" text="{text}"/>
				</panel>
